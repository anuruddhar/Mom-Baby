#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Core
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using AutoMapper;
using Mobile.Core.Extensions;
using Mobile.FormModel;
using Mobile.Helpers;
using Mobile.Models.Baby;
using Mobile.Models.Mother;
using Plugin.Geolocator.Abstractions;
using System;
using XamarinMap = Xamarin.Forms.Maps;
#endregion	  


namespace Mobile
{
    public static class InitAutoMapper {


        public static IMapper Initialize() {
            try {
                var config = new MapperConfiguration(cfg => {

                    #region Baby
                    // Mapping for sending data from client to server - Baby
                    cfg.CreateMap<BabyFormModel, Baby>()
                    .ForMember(dest => dest.MotherId, opt => opt.MapFrom(src => src.SelectedMotherId))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.StringVal))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.StringVal))
                    .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.SelectedDob))
                    .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.SelectedSexId))
                    .ForMember(dest => dest.NextAppointmentDate, opt => opt.MapFrom(src => src.NextAppointmentDateTime));

                    // Mapping for receiving data from server to client - Baby
                    cfg.CreateMap<Baby, BabyFormModel>()
                    .ForPath(dest => dest.Mother.StringVal, opt => opt.MapFrom(src => src.MotherName))
                    .ForPath(dest => dest.FirstName.StringVal, opt => opt.MapFrom(src => src.FirstName))
                    .ForPath(dest => dest.LastName.StringVal, opt => opt.MapFrom(src => src.LastName))
                    .ForPath(dest => dest.Dob.StringVal, opt => opt.MapFrom(src => src.Dob))
                    .ForPath(dest => dest.Sex.StringVal, opt => opt.MapFrom(src => src.Sex))
                    .ForPath(dest => dest.NextAppointmentDate.StringVal, opt => opt.MapFrom(src => src.NextAppointmentDate));
                    #endregion

                    #region Mother
                    // Mapping for sending data from client to server - Mother
                    cfg.CreateMap<MotherFormModel, Mother>()
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.StringVal))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.StringVal))
                    .ForMember(dest => dest.Nic, opt => opt.MapFrom(src => src.Nic.StringVal))
                    .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.SelectedDob))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.StringVal))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.StringVal))
                    .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation.StringVal))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.StringVal))
                    .ForMember(dest => dest.NextAppointmentDate, opt => opt.MapFrom(src => src.NextAppointmentDateTime));

                    // Mapping for receiving data from server to client - Mother
                    cfg.CreateMap<Mother, MotherFormModel>()
                    .ForPath(dest => dest.FirstName.StringVal, opt => opt.MapFrom(src => src.FirstName))
                    .ForPath(dest => dest.LastName.StringVal, opt => opt.MapFrom(src => src.LastName))
                    .ForPath(dest => dest.Nic.StringVal, opt => opt.MapFrom(src => src.Nic))
                     .ForPath(dest => dest.Dob.StringVal, opt => opt.MapFrom(src => src.Dob.ToString(AppConstant.DatTimeFormat.YYYY_MM_DD)))
                    .ForPath(dest => dest.SelectedDob, opt => opt.MapFrom(src => src.Dob))
                    .ForPath(dest => dest.Phone.StringVal, opt => opt.MapFrom(src => src.Phone))
                    .ForPath(dest => dest.Address.StringVal, opt => opt.MapFrom(src => src.Address))
                    .ForPath(dest => dest.Occupation.StringVal, opt => opt.MapFrom(src => src.Occupation))
                    .ForPath(dest => dest.Email.StringVal, opt => opt.MapFrom(src => src.Email))
                    .ForPath(dest => dest.NextAppointmentDate.StringVal, opt => opt.MapFrom(src => src.NextAppointmentDate.ToString(AppConstant.DatTimeFormat.YYYY_MM_DD)))
                    .ForPath(dest => dest.SelectedNextAppointmentDate, opt => opt.MapFrom(src => src.NextAppointmentDate))
                    .ForPath(dest => dest.NextAppointmentTime.StringVal, opt => opt.MapFrom(src => src.NextAppointmentDate.ToString(AppConstant.DatTimeFormat.HH_mm)))
                    //.ForPath(dest => dest.SelectedNextAppointmentTime, opt => opt.MapFrom(src => src.NextAppointmentDate))
                    ;
                    #endregion


                    #region BabyAppoinment

                    // Mapping for sending data from client to server - Mother
                    cfg.CreateMap<BabyAppoinmentFormModel, BabyAppoinment>()
                    .ForMember(dest => dest.BabyId, opt => opt.MapFrom(src => src.SelectedBabyId))
                    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight.StringVal))
                    .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height.StringVal))
                    .ForMember(dest => dest.Vaccine, opt => opt.MapFrom(src => src.Vaccine.StringVal))
                    .ForMember(dest => dest.Instruction, opt => opt.MapFrom(src => src.Instruction.StringVal));
                    #endregion

                    #region MotherAppoinment
                    // Mapping for sending data from client to server - Mother
                    cfg.CreateMap<MotherAppoinmentFormModel, MotherAppoinment>()
                    .ForMember(dest => dest.MotherId, opt => opt.MapFrom(src => src.SelectedMotherId))
                    .ForMember(dest => dest.HealthCondition, opt => opt.MapFrom(src => src.HealthCondition.StringVal))
                    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight.StringVal))
                    .ForMember(dest => dest.BloodPressure, opt => opt.MapFrom(src => src.BloodPressure.StringVal))
                    .ForMember(dest => dest.GlucouseLevel, opt => opt.MapFrom(src => src.GlucouseLevel.StringVal))
                    .ForMember(dest => dest.Vaccine, opt => opt.MapFrom(src => src.Vaccine.StringVal))
                    .ForMember(dest => dest.Instruction, opt => opt.MapFrom(src => src.Instruction.StringVal));
                    #endregion
                    

                });

                var mapper = config.CreateMapper();

                 return mapper;
            } catch (Exception) {
            }

            return null;
        }

    }
}
