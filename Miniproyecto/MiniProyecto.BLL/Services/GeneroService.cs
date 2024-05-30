using MiniProyecto.BLL.Contracts;
using MiniProyecto.BLL.core;
using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.Models;
using MiniProyecto.BLL.Responses.GeneroResponses;
using MiniProyecto.DAL.Entities;
using MiniProyecto.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProyecto.BLL.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGenero _generos;

        public GeneroService(IGenero generos)
        {
            _generos = generos;
        }

        public GeneroRemoveResponses Remove(GeneroDTO generoDto)
        {
            GeneroRemoveResponses result = new GeneroRemoveResponses();
            try
            {
                MiniProyecto.DAL.Entities.Genero genero = new MiniProyecto.DAL.Entities.Genero
                {
                    
                    IDgenero = generoDto.IDgenero,
                    Tipo= generoDto.Tipo
                };
                _generos.Remove(genero);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar eliminar el genero: {ex}";
            }
            return result;
        }

        public GeneroSaveResponses Save(GeneroDTO generoDto)
        {
            GeneroSaveResponses result = new GeneroSaveResponses();
            try
            {
                MiniProyecto.DAL.Entities.Genero genero = new MiniProyecto.DAL.Entities.Genero
                {
                    IDgenero = generoDto.IDgenero,
                    Tipo = generoDto.Tipo
                };
                _generos.Save(genero);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar guardar el genero: {ex}";
            }
            return result;
        }

        public GeneroUpdateResponses Update(GeneroDTO generoDto)
        {
            GeneroUpdateResponses result = new GeneroUpdateResponses();
            try
            {
                MiniProyecto.DAL.Entities.Genero genero = new MiniProyecto.DAL.Entities.Genero
                {
                    IDgenero = generoDto.IDgenero,
                    Tipo = generoDto.Tipo
                };
                _generos.Update(genero);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar actualizar el genero: {ex}";
            }
            return result;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from genero in this._generos.GetEntities()
                             select new GeneroModel
                             {
                                 IDgenero = genero.IDgenero,
                                 Tipo = genero.Tipo
                             }).ToList();
                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al obtener los generos: {ex}";
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MiniProyecto.DAL.Entities.Genero genero = _generos.GetEntity(id);
                if (genero != null)
                {
                    GeneroModel generoModel = new GeneroModel
                    {
                        IDgenero = genero.IDgenero,
                        Tipo = genero.Tipo
                    };
                    result.Data = generoModel;
                }
                else
                {
                    result.Success = false;
                    result.Message = $"Género con ID {id} no encontrado.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al obtener el género: {ex}";
            }
            return result;
        }
    }
}