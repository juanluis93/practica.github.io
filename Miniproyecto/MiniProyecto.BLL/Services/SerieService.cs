using MiniProyecto.BLL.Contracts;
using MiniProyecto.BLL.core;
using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.Models;
using MiniProyecto.BLL.Responses.SerieResponses;
using MiniProyecto.DAL.Interfaces;
using MiniProyecto.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using MiniProyecto.BLL.Responses;
using MiniProyecto.DAL.Entities;

namespace MiniProyecto.BLL.Services
{
    public class SerieService : ISeriesService
    {
        private readonly ISeries _series;

        public SerieService(ISeries series)
        {
            _series = series;
        }

        public SerieRemoveResponses Remove(SeriesDTO serieDto)
        {
            SerieRemoveResponses result = new SerieRemoveResponses();
            try
            {
                MiniProyecto.DAL.Entities.Series serie = new MiniProyecto.DAL.Entities.Series
                {
                Nombre = serieDto.Nombre,
                SerieID = serieDto.SerieID,
                Descripcion = serieDto.Descripcion,
                Imagen = serieDto.Imagen,
                IDgenero2 = serieDto.IDgenero2,
                IDcategoria = serieDto.IDcategoria,
                IDgenero = serieDto.IDcategoria,
                IDproductor = serieDto.IDproductor,
                URL = serieDto.URL


                };
                _series.Remove(serie);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar eliminar la serie: {ex}";
            }
            return result;
        }

        public SerieSaveResponses Save(SeriesDTO serieDto)
        {
            SerieSaveResponses result = new SerieSaveResponses();
            try
            {
                MiniProyecto.DAL.Entities.Series series = new MiniProyecto.DAL.Entities.Series
                {
                    Nombre = serieDto.Nombre,
                    SerieID = serieDto.SerieID,
                    Descripcion = serieDto.Descripcion,
                    Imagen = serieDto.Imagen,
                    IDcategoria = serieDto.IDcategoria,
                    IDgenero = serieDto.IDgenero,
                    IDproductor = serieDto.IDproductor,
                    IDgenero2 = serieDto.IDgenero2,
                    URL = serieDto.URL
                };
                _series.Save(series);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar guardar la serie: {ex}";
            }
            return result;
        }

        public SerieUpdateResponses Update(SeriesDTO serieDto)
        {
            SerieUpdateResponses result = new SerieUpdateResponses();
            try
            {
                MiniProyecto.DAL.Entities.Series series = new MiniProyecto.DAL.Entities.Series
                {
                    Nombre = serieDto.Nombre,
                    SerieID = serieDto.SerieID,
                    Descripcion = serieDto.Descripcion,
                    Imagen = serieDto.Imagen,
                    IDcategoria = serieDto.IDcategoria,
                    IDgenero = serieDto.IDgenero,
                    IDproductor = serieDto.IDproductor,
                    IDgenero2 = serieDto.IDgenero2,
                    URL = serieDto.URL
                };
                _series.Update(series);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar actualizar la serie: {ex}";
            }
            return result;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from serie in this._series.GetEntities()
                             select new SeriesModel
                             {
                                 Nombre = serie.Nombre,
                                 SerieID = serie.SerieID,
                                 Descripcion = serie.Descripcion,
                                 Imagen = serie.Imagen,
                                 IDcategoria = serie.IDcategoria,
                                 IDgenero = serie.IDgenero,
                                 IDproductor = serie.IDproductor,
                                 IDgenero2 = serie.IDgenero2,
                                  URL = serie.URL
                             }).ToList();
                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al obtener las series: {ex}";
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MiniProyecto.DAL.Entities.Series serie = _series.GetEntity(id);
                SeriesModel serieModel = new SeriesModel
                {
              
                    SerieID = serie.SerieID,
                    IDcategoria = serie.IDcategoria,
                    IDgenero = serie.IDgenero,
                    IDproductor = serie.IDproductor,
                    Nombre = serie.Nombre,
                    Descripcion = serie.Descripcion,
                    Imagen = serie.Imagen,
                    IDgenero2 = serie.IDgenero2,
                    URL = serie.URL

                };
                result.Data = serieModel;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al obtener la serie: {ex}";
            }
            return result;
        }
    }
}