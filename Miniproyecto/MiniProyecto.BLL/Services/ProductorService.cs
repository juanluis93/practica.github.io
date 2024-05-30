using MiniProyecto.BLL.Contracts;
using MiniProyecto.BLL.core;
using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.Models;
using MiniProyecto.BLL.Responses.ProductorResponses;
using MiniProyecto.DAL.Entities;
using MiniProyecto.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProyecto.BLL.Services
{
    public class ProductorService : IProductorService
    {
        private readonly IProductor _productores;

        public ProductorService(IProductor productores)
        {
            _productores = productores;
        }

        public ProductorRemoveResponses Remove(ProductorDTO productorDto)
        {
            ProductorRemoveResponses result = new ProductorRemoveResponses();
            try
            {
                MiniProyecto.DAL.Entities.Productor productor = new MiniProyecto.DAL.Entities.Productor
                {
                
                    Nombre = productorDto.Nombre,
                    Apellido = productorDto.Apellido,
                    Empresa = productorDto.Empresa,
                    IDproductor=productorDto.IDproductor
                   
                };
                _productores.Remove(productor);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar eliminar el productor: {ex}";
            }
            return result;
        }

        public ProductorSaveResponses Save(ProductorDTO productorDto)
        {
            ProductorSaveResponses result = new ProductorSaveResponses();
            try
            {
                MiniProyecto.DAL.Entities.Productor productor = new MiniProyecto.DAL.Entities.Productor
                {
                   
                    Nombre = productorDto.Nombre,
                    Apellido = productorDto.Apellido,
                    Empresa = productorDto.Empresa,
                    IDproductor=productorDto.IDproductor
                };
                _productores.Save(productor);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar guardar el productor: {ex}";
            }
            return result;
        }

        public ProductorUpdateResponses Update(ProductorDTO productorDto)
        {
            ProductorUpdateResponses result = new ProductorUpdateResponses();
            try
            {
                MiniProyecto.DAL.Entities.Productor productor = new MiniProyecto.DAL.Entities.Productor
                {

                    Nombre = productorDto.Nombre,
                    Apellido = productorDto.Apellido,
                    Empresa = productorDto.Empresa,
                    IDproductor = productorDto.IDproductor
                };
                _productores.Update(productor);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar actualizar el productor: {ex}";
            }
            return result;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from productor in this._productores.GetEntities()
                             select new ProductorModel
                             {

                                 Nombre = productor.Nombre,
                                 Apellido = productor.Apellido,
                                 Empresa = productor.Empresa,
                                 IDproductor = productor.IDproductor
                             }).ToList();
                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al obtener los productores: {ex}";
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MiniProyecto.DAL.Entities.Productor productor = _productores.GetEntity(id);
                ProductorModel productorModel = new ProductorModel
                {
                    Nombre = productor.Nombre,
                    Apellido = productor.Apellido,
                    Empresa = productor.Empresa,
                    IDproductor = productor.IDproductor
                };
                result.Data = productorModel;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al obtener el productor: {ex}";
            }
            return result;
        }
    }
}