﻿using AutoMapper;
using LattesDataExtraction.Application.Contracts;
using LattesDataExtraction.Application.Mappers;
using LattesDataExtraction.Application.Services;
using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Factories;
using LattesDataExtraction.Domain.Services;
using LattesDataExtraction.Infraestructure.Context;
using LattesDataExtraction.Infraestructure.Reporitories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LattesDataExtraction.Infraestructure.Ioc
{
    public static class InjectionConfig
    {
        public static void AddServicesDependency(this IServiceCollection services)
        {
            #region DatabaseContext

            services.AddDbContext<AcademicResearcherEFContext>(i => i.UseInMemoryDatabase("AcademicResearchers"));

            #endregion

            #region Services

            services.AddScoped<ILattesDataExtractionService, LattesDataExtractionService>();
            services.AddScoped<IAcademicResearcherDataExtractionService, AcademicResearcherDataExtractionService>();

            #endregion

            #region Factories

            services.AddScoped<IGetDataInformationFactory, GetDataInformationFactory>();
            services.AddScoped<IAcademicResearcherReadService, AcademicResearcherReadService>();

            #endregion
            
            #region Repositories

            services.AddScoped<IAcademicResearcherRepository, AcademicResearcherRepository>();

            #endregion
        }

        public static void AddMappersProfiles(this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddProfile(new ApplicationMappingProfile());
        }
    }
}