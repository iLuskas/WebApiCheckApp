using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Services
{
    public class ApplicationServiceInspecao : IApplicationServiceInspecao
    {
        private readonly IServiceInspecao _serviceInspecao;
        private readonly IMapper _mapper;

        public ApplicationServiceInspecao(IServiceInspecao serviceInspecao, IMapper mapper)
        {
            _serviceInspecao = serviceInspecao;
            _mapper = mapper;
        }

        public void Add(InspecaoDTO obj)
        {
            var objEntity = _mapper.Map<Inspecao>(obj);

            _serviceInspecao.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceInspecao.Dispose();
        }

        public IEnumerable<InspecaoDTO> GetAll()
        {
            var listObj = _serviceInspecao.GetAll();
            return _mapper.Map<IEnumerable<InspecaoDTO>>(listObj);
        }

        public InspecaoDTO GetById(int id)
        {
            var objEntity = _serviceInspecao.GetById(id);
            
            return _mapper.Map<InspecaoDTO>(objEntity);
        }

        public InspecaoDTO GetInspecaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId)
        {
            var objEntity = _serviceInspecao.GetInspecaoByEquipIdAndAgeId(equipamentoId, agendamentoId);

            var objMapped = _mapper.Map<InspecaoDTO>(objEntity);

            objMapped.ImagemOcorrenciaBase64 = string.Empty;

            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fullPathImg = $"{pathToSave}/{objMapped.ImagemOcorrencia}";
            if (File.Exists(fullPathImg))
            {
                byte[] imageArray = File.ReadAllBytes(fullPathImg);
                objMapped.ImagemOcorrenciaBase64 = Convert.ToBase64String(imageArray);
            }
            
            return objMapped;
        }

        public void Remove(InspecaoDTO obj)
        {
            var objEntity = _mapper.Map<Inspecao>(obj);
            _serviceInspecao.Remove(objEntity);
        }

        public void Update(InspecaoDTO obj)
        {
            var objEntity = _mapper.Map<Inspecao>(obj);
            _serviceInspecao.Update(objEntity);
        }
    }
}
