USE [pempmeddb]
GO
/****** Object:  Table [dbo].[BillingMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillingMst](
	[Id] [int] NOT NULL,
	[BillNo] [nvarchar](50) NULL,
	[BillDate] [datetime] NULL,
	[CompanyId] [int] NULL,
	[CompanyName] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NULL,
	[PatientId] [int] NULL,
	[RegNo] [nvarchar](50) NULL,
	[PatientName] [nvarchar](50) NULL,
	[Treatment] [nvarchar](200) NULL,
	[Patientamt] [nvarchar](50) NULL,
	[Companyamt] [nvarchar](50) NULL,
	[DateofPayment] [datetime] NULL,
	[Amount] [nvarchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyMst](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyName] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[Country] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[zone] [nvarchar](50) NULL,
	[Pincode] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[Designation] [nvarchar](50) NULL,
	[ContactName1] [nvarchar](50) NULL,
	[ContactNumber1] [nvarchar](50) NULL,
	[Designation1] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[PayingAmt] [nvarchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdatDate] [datetime] NULL,
	[Status] [nvarchar](10) NULL,
	[Vat] [nvarchar](50) NULL,
	[GSTIN] [nvarchar](200) NULL,
	[ServiceType] [nvarchar](50) NULL,
	[Panno] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorMst](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[MobileNumber] [int] NULL,
	[Insertdate] [datetime] NULL,
	[Updatedate] [datetime] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralExaminationPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralExaminationPatientMst](
	[Id] [int] NOT NULL,
	[PatientId] [int] NULL,
	[RegNo] [nvarchar](50) NULL,
	[Height] [nvarchar](50) NULL,
	[Weight] [nvarchar](50) NULL,
	[Pluse] [nvarchar](50) NULL,
	[BP] [nvarchar](50) NULL,
	[TempInF] [nvarchar](50) NULL,
	[Respiration] [nvarchar](50) NULL,
	[Built] [nvarchar](50) NULL,
	[Nutrition] [nvarchar](50) NULL,
	[Nails] [nvarchar](50) NULL,
	[Teeth] [nvarchar](50) NULL,
	[Gums] [nvarchar](50) NULL,
	[OralHygene] [nvarchar](50) NULL,
	[LymphNodes] [nvarchar](50) NULL,
	[Eyes] [nvarchar](50) NULL,
	[Spine] [nvarchar](50) NULL,
	[Tongue] [nvarchar](50) NULL,
	[Ent] [nvarchar](50) NULL,
	[BonesJoints] [nvarchar](50) NULL,
	[Skin] [nvarchar](50) NULL,
	[HearingR] [nvarchar](50) NULL,
	[HearingL] [nvarchar](50) NULL,
	[EyesVisionR] [nvarchar](50) NULL,
	[EyesVisionL] [nvarchar](50) NULL,
	[ColourVision] [nvarchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestigationRemarkPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestigationRemarkPatientMst](
	[Id] [int] NOT NULL,
	[PatientId] [int] NULL,
	[RegNo] [nvarchar](50) NULL,
	[BloodReport] [nvarchar](50) NULL,
	[UrineReport] [nvarchar](50) NULL,
	[XRayChestReport] [nvarchar](50) NULL,
	[PFT] [nvarchar](50) NULL,
	[ECG] [nvarchar](50) NULL,
	[Audiometry] [nvarchar](50) NULL,
	[Spirometry] [nvarchar](50) NULL,
	[FitnessCertificate] [nvarchar](50) NULL,
	[BloodReportAttached] [nvarchar](300) NULL,
	[UrineReportAttached] [nvarchar](300) NULL,
	[XRayChestReportAttached] [nvarchar](300) NULL,
	[PFTAttached] [nvarchar](300) NULL,
	[ECGAttached] [nvarchar](300) NULL,
	[AudiometryAttached] [nvarchar](300) NULL,
	[SpirometryAttached] [nvarchar](300) NULL,
	[FitnessCertificateAttached] [nvarchar](300) NULL,
	[Advise] [nvarchar](200) NULL,
	[Remarks] [nvarchar](500) NULL,
	[DoctorsRemark] [nvarchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientCheckupMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientCheckupMst](
	[Id] [int] NOT NULL,
	[UserId] [int] NULL,
	[PatientId] [int] NULL,
	[RegNo] [nvarchar](50) NULL,
	[PatientName] [nvarchar](50) NULL,
	[CompanyId] [int] NULL,
	[CompanyName] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NULL,
	[DoctorId] [int] NULL,
	[DoctorName] [nvarchar](50) NULL,
	[Treatment] [nvarchar](200) NULL,
	[Checkupdate] [datetime] NULL,
	[NextCheckupdate] [datetime] NULL,
	[CompanyPayAmt] [nvarchar](50) NULL,
	[PatientPayAmt] [nvarchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientformImage]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientformImage](
	[PatientId] [int] NOT NULL,
	[formImage1] [nvarchar](500) NULL,
	[formImage2] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientMst](
	[Id] [int] NOT NULL,
	[UserId] [int] NULL,
	[DoctorId] [int] NULL,
	[CompanyId] [int] NULL,
	[RegNo] [nvarchar](50) NULL,
	[DateOn] [datetime] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DOB] [datetime] NULL,
	[Gender] [nvarchar](50) NULL,
	[Age] [decimal](18, 0) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[Mariatal_Status] [nvarchar](50) NULL,
	[Photo] [nvarchar](200) NULL,
	[IDMark] [nvarchar](50) NULL,
	[Diet] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[PersonalHabbits] [nvarchar](200) NULL,
	[DominantHand] [nvarchar](100) NULL,
	[Immunisation] [nvarchar](50) NULL,
	[FamilyHistory] [nvarchar](200) NULL,
	[PersonalHistory] [nvarchar](200) NULL,
	[PastHistory] [nvarchar](200) NULL,
	[smokehabbit] [nvarchar](10) NULL,
	[smokehabbityear] [nvarchar](20) NULL,
	[smokehabbitday] [nvarchar](20) NULL,
	[MenstrualCycle] [nvarchar](100) NULL,
	[OtherComplaints] [nvarchar](100) NULL,
	[PresentJobDesc] [nvarchar](200) NULL,
	[InsertDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [nvarchar](10) NULL,
	[Title] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientPreviousCompanyMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientPreviousCompanyMst](
	[Id] [int] NOT NULL,
	[PatientId] [int] NULL,
	[RegNo] [nvarchar](50) NULL,
	[NameOfCompany] [nvarchar](50) NULL,
	[NoOfyrs] [int] NULL,
	[NatureOfJob] [nvarchar](200) NULL,
	[AnyOccupationalHealthAilments] [nvarchar](200) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMst](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[RoleName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemExaminationPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemExaminationPatientMst](
	[Id] [int] NOT NULL,
	[PatientId] [int] NULL,
	[RegNo] [nvarchar](50) NULL,
	[Cardio_HeartSound] [nvarchar](50) NULL,
	[Cardio_Murmur] [nvarchar](50) NULL,
	[Respir_ChestMovements] [nvarchar](50) NULL,
	[Respir_Trachea] [nvarchar](50) NULL,
	[Respir_BreathSounds] [nvarchar](50) NULL,
	[Respir_AdventitiousSounds] [nvarchar](50) NULL,
	[Gastrointestional_Liver] [nvarchar](50) NULL,
	[Gastrointestional_Spleen] [nvarchar](50) NULL,
	[CentralNervous_HigherFunction] [nvarchar](50) NULL,
	[CentralNervous_SensorySystem] [nvarchar](50) NULL,
	[CentralNervous_MotorSystem] [nvarchar](50) NULL,
	[GenitoUrinarySystem] [nvarchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestMst](
	[Id] [int] NULL,
	[UserId] [int] NULL,
	[CompanyId] [int] NULL,
	[PatientId] [int] NULL,
	[Date] [datetime] NULL,
	[TestName] [nvarchar](50) NULL,
	[Cost] [nvarchar](50) NULL,
	[InsertedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TreatmentMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreatmentMst](
	[Id] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[EmployeeId] [int] NULL,
	[Date] [date] NULL,
	[Description] [nvarchar](500) NULL,
	[Amount] [nvarchar](100) NULL,
	[UserId] [int] NULL,
	[DoctorId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMst](
	[Id] [int] NOT NULL,
	[RoleId] [int] NULL,
	[RoleName] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Pincode] [nvarchar](50) NULL,
	[InsertedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisitingMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitingMst](
	[Id] [int] NOT NULL,
	[VisitDate] [date] NULL,
	[NoofDays] [int] NULL,
	[CandidateName] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[Amount] [nvarchar](50) NULL,
	[CompanyId] [int] NULL,
	[BillDate] [date] NULL,
	[BillNo] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ups_InsertInvestigationRemarkPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[ups_InsertInvestigationRemarkPatientMst]
(
@PatientId int,@RegNo nvarchar(50),@BloodReport nvarchar(50),@UrineReport nvarchar(50),@XRayChestReport nvarchar(50),
@PFT nvarchar(50),@ECG nvarchar(50),@Audiometry nvarchar(50),@Spirometry nvarchar(50),@FitnessCertificate nvarchar(50),@BloodReportAttached nvarchar(300),@UrineReportAttached nvarchar(300),@XRayChestReportAttached nvarchar(300),
@PFTAttached nvarchar(300),@ECGAttached nvarchar(300),@AudiometryAttached nvarchar(300),@SpirometryAttached nvarchar(300),@FitnessCertificateAttached nvarchar(300),@Advise nvarchar(200),@Remarks nvarchar(200),@DoctorsRemark nvarchar(50)
)
as Begin
 If Exists(select * from InvestigationRemarkPatientMst where PatientId=@PatientId and RegNo=@RegNo )
 Begin
 Select 0
 End
 Else
 Begin
Declare @Id int
select @Id=count(Id)+1 from InvestigationRemarkPatientMst
insert into InvestigationRemarkPatientMst(Id,PatientId,RegNo,BloodReport,UrineReport,XRayChestReport,PFT,ECG,Audiometry,Spirometry,FitnessCertificate,BloodReportAttached,UrineReportAttached,XRayChestReportAttached,
PFTAttached,ECGAttached,AudiometryAttached,SpirometryAttached,FitnessCertificateAttached,Advise,Remarks,DoctorsRemark,InsertDate,Status) values
              (@Id,@PatientId,@RegNo,@BloodReport,@UrineReport,@XRayChestReport,@PFT,@ECG,@Audiometry,@Spirometry,@FitnessCertificate,@BloodReportAttached,@UrineReportAttached,@XRayChestReportAttached,
@PFTAttached,@ECGAttached,@AudiometryAttached,@SpirometryAttached,@FitnessCertificateAttached,@Advise,@Remarks,@DoctorsRemark,Current_Timestamp,'1')
select @Id
End
End





GO
/****** Object:  StoredProcedure [dbo].[usp_deletePatientbyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[usp_deletePatientbyId](@PatientId int)
as 
Begin
delete from PatientMst where Id=@PatientId
delete from GeneralExaminationPatientMst where PatientId=@PatientId
delete from InvestigationRemarkPatientMst where PatientId=@PatientId
delete from SystemExaminationPatientMst where PatientId=@PatientId
delete from PatientPreviousCompanyMst where PatientId=@PatientId

End
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteTreamentbyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_deleteTreamentbyId](@Id int)
as Begin
delete from TreamentMst where Id=@Id
End
GO
/****** Object:  StoredProcedure [dbo].[usp_DeletetUserMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_DeletetUserMst](@RoleId int)
As 
Begin 
Delete from UserMst where RoleId=@RoleId
select 1
End 

GO
/****** Object:  StoredProcedure [dbo].[usp_displayPatient]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[usp_displayPatient]
as 
Begin
select Id,RegNo+'_'+FirstName+'_'+LastName as 'RegNo' from PatientMst 
 End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllGeneralExaminationPatientMstbycomapyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllGeneralExaminationPatientMstbycomapyId](@CompanyId int)
as
Begin
SELECT p.Id,p.PatientId,p.RegNo,p.Height,p.Weight,p.Pluse,BP,p.TempInF,p.Respiration,p.Built,p.Nutrition,p.Nails,p.Teeth,p.Gums,p.OralHygene,p.LymphNodes,p.Eyes,p.Spine,p.Tongue,p.Ent,p.BonesJoints,p.Skin,p.HearingR,p.HearingL,p.EyesVisionR,p.EyesVisionL,p.ColourVision  FROM GeneralExaminationPatientMst  p,PatientMst m where p.PatientId=m.Id and m.CompanyId=@CompanyId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllInvestigationRemarkPatientMstbycompanyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllInvestigationRemarkPatientMstbycompanyId](@CompanyId int)
as
Begin
SELECT p.Id,p.PatientId,p.RegNo,p.BloodReport,p.BloodReportAttached,p.UrineReport,p.UrineReportAttached,p.XRayChestReport,p.XRayChestReportAttached,p.PFT,p.PFTAttached,p.ECG,p.ECGAttached,p.Audiometry,p.AudiometryAttached,p.Spirometry,p.SpirometryAttached,p.FitnessCertificate,p.FitnessCertificateAttached,p.Advise,p.Remarks,p.DoctorsRemark FROM InvestigationRemarkPatientMst  p,PatientMst m where p.PatientId=m.Id and m.CompanyId=@CompanyId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllPatientbyCompanyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllPatientbyCompanyId]
(@CompanyId int)
as
Begin
SELECT Id,UserId,DoctorId,CompanyId,RegNo,DateOn,FirstName,LastName,DOB,Gender,Age,MobileNumber,Mariatal_Status,Photo,IDMark,Diet,Address,PersonalHabbits,DominantHand,Immunisation,FamilyHistory,PersonalHistory,PastHistory,smokehabbit,smokehabbityear,smokehabbitday,MenstrualCycle,OtherComplaints,PresentJobDesc from PatientMst where CompanyId=@CompanyId
End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllPatientPreviouscompanymstbycomapyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllPatientPreviouscompanymstbycomapyId](@CompanyId int)
as
Begin
SELECT p.Id,p.PatientId,p.RegNo,p.NameOfCompany,p.NoOfyrs,p.NatureOfJob,p.AnyOccupationalHealthAilments  FROM PatientPreviousCompanyMst p,PatientMst m where p.PatientId=m.Id and m.CompanyId=@CompanyId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllSystemExaminationPatientMstbycompanyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAllSystemExaminationPatientMstbycompanyId](@CompanyId int)
as
Begin
SELECT p.Id,p.PatientId,p.RegNo,p.Cardio_HeartSound,p.Cardio_Murmur,p.Respir_ChestMovements,p.Respir_Trachea,p.Respir_BreathSounds,p.Respir_AdventitiousSounds,p.Gastrointestional_Liver,p.Gastrointestional_Spleen,p.CentralNervous_HigherFunction,p.CentralNervous_SensorySystem,p.CentralNervous_MotorSystem,p.GenitoUrinarySystem FROM SystemExaminationPatientMst  p,PatientMst m where p.PatientId=m.Id and m.CompanyId=@CompanyId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAlltestinvices]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE       procedure [dbo].[usp_GetAlltestinvices](@CompanyId int, @months int,@years int)
as
Begin
select Row_Number() over (order by t.PatientId) Nos,t.Id,t.PatientId, (p.FirstName+' '+p.LastName)as Employee,CONVERT(DATE,t.Date) as 'Date',t.Cost as Amount from TestMst t, PatientMst p where p.Id=t.PatientId and p.CompanyId=t.CompanyId and t.CompanyId=@CompanyId and MONTH(t.Date)=@months and YEAR(t.Date)=@years

--select Row_Number() over (order by t.PatientId) Nos,t.PatientId,(p.FirstName+' '+p.LastName) Employee,count(t.PatientId) TotalTest,'Test_Details'as Details,sum(convert(decimal(10,2),t.Cost)) Amount from TestMst t,PatientMst p where t.CompanyId=p.CompanyId and t.PatientId=P.Id and MONTH(t.Date)=@months and year(t.Date)=@years and t.companyId=@CompanyId group by t.PatientId,p.FirstName,p.LastName
End


GO
/****** Object:  StoredProcedure [dbo].[usp_GetAlltestinvices1]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE       procedure [dbo].[usp_GetAlltestinvices1](@CompanyId int, @months int,@years int)
as
Begin
select t.Id,t.PatientId, (p.FirstName+' '+p.LastName)as Employee,CONVERT(DATE,t.Date) as 'Date',t.Cost as Amount from TestMst t, PatientMst p where p.Id=t.PatientId and p.CompanyId=t.CompanyId and t.CompanyId=@CompanyId and MONTH(t.Date)=@months and YEAR(t.Date)=@years

--select Row_Number() over (order by t.PatientId) Nos,t.PatientId,(p.FirstName+' '+p.LastName) Employee,count(t.PatientId) TotalTest,'Test_Details'as Details,sum(convert(decimal(10,2),t.Cost)) Amount from TestMst t,PatientMst p where t.CompanyId=p.CompanyId and t.PatientId=P.Id and MONTH(t.Date)=@months and year(t.Date)=@years and t.companyId=@CompanyId group by t.PatientId,p.FirstName,p.LastName
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAlltestinvices2]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec usp_GetAlltestinvices2 1,11,2024
CREATE  procedure [dbo].[usp_GetAlltestinvices2](@CompanyId int, @months int,@years int)
as
Begin
Declare @Description nvarchar(100)
set @Description='Pre Medical Test';
select Row_Number() over (order by t.PatientId) Nos,t.Id,t.PatientId, (p.FirstName+' '+p.LastName)as Employee,CONVERT(DATE,t.Date) as 'Date',@Description as Description,t.Cost as Amount from TestMst t, PatientMst p where p.Id=t.PatientId and p.CompanyId=t.CompanyId and t.CompanyId=@CompanyId and MONTH(t.Date)=@months and YEAR(t.Date)=@years

--select Row_Number() over (order by t.PatientId) Nos,t.PatientId,(p.FirstName+' '+p.LastName) Employee,count(t.PatientId) TotalTest,'Test_Details'as Details,sum(convert(decimal(10,2),t.Cost)) Amount from TestMst t,PatientMst p where t.CompanyId=p.CompanyId and t.PatientId=P.Id and MONTH(t.Date)=@months and year(t.Date)=@years and t.companyId=@CompanyId group by t.PatientId,p.FirstName,p.LastName
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAlltreatmentinvices]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec usp_GetAlltestinvices2 1,11,2024
CREATE  procedure [dbo].[usp_GetAlltreatmentinvices](@CompanyId int, @months int,@years int)
as
Begin
select Row_Number() over (order by t.EmployeeId) Nos,t.Id,t.EmployeeId, (p.FirstName+' '+p.LastName)as Employee,CONVERT(DATE,t.Date) as 'Date',t.Description,t.Amount  from TreatmentMst t, PatientMst p where p.Id=t.EmployeeId and p.CompanyId=t.CompanyId and t.CompanyId=@CompanyId and MONTH(t.Date)=@months and YEAR(t.Date)=@years

--select Row_Number() over (order by t.PatientId) Nos,t.PatientId,(p.FirstName+' '+p.LastName) Employee,count(t.PatientId) TotalTest,'Test_Details'as Details,sum(convert(decimal(10,2),t.Cost)) Amount from TestMst t,PatientMst p where t.CompanyId=p.CompanyId and t.PatientId=P.Id and MONTH(t.Date)=@months and year(t.Date)=@years and t.companyId=@CompanyId group by t.PatientId,p.FirstName,p.LastName
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCompanyAddress]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetCompanyAddress](@CompanyId int)
as
Begin
select CompanyName,Address+Country+State+City+Zone+Pincode+EmailId+Fax as'Address'  from  CompanyMst where Id=@CompanyId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCompanyMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE      procedure [dbo].[usp_GetCompanyMst]
as
Begin
SELECT Id,UserId,CompanyName,Address,EmailId,ContactName,ContactNumber,Designation,ServiceType,Panno from CompanyMst
End


GO
/****** Object:  StoredProcedure [dbo].[usp_GetCompanyMstByserchId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE      procedure [dbo].[usp_GetCompanyMstByserchId](@companyId int)
as
Begin
SELECT Id,UserId,CompanyName,Address,EmailId,ContactName,ContactNumber,Designation,ServiceType,Panno from CompanyMst where Id=@companyId
End





GO
/****** Object:  StoredProcedure [dbo].[usp_getdestest]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_getdestest](@PatientId int,@CompanyId int)
as
Begin
declare @result varchar(max)
set @result = ''

select @result = @result + m.TestCategory +','  from TestMst t,TestCategoryMst m where t.TestName=m.Id and t.PatientId=@PatientId and t.CompanyId=@CompanyId
select @result as TestDetails,@PatientId as PatientId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetGeneralExaminationPatientMstbyPatientId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[usp_GetGeneralExaminationPatientMstbyPatientId](@PatientId int)
as Begin
select * from GeneralExaminationPatientMst where PatientId=@PatientId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetInvestigationRemarkPatientMstbyPatientId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[usp_GetInvestigationRemarkPatientMstbyPatientId](@PatientId int)
as Begin
select * from InvestigationRemarkPatientMst where PatientId=@PatientId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetInvoicespatientdetail]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_GetInvoicespatientdetail](@CompanyId int,@months int,@years int)
as
Begin
select Row_Number() over(order by PatientId)as No,PatientId,PatientName,Treatment,count(PatientId)as VisitDays,CompanyPayAmt as Costs,sum(convert(Decimal(10,2),CompanyPayAmt)) as TotalAmount from PatientcheckupMst where CompanyId=@CompanyId and month(Checkupdate)=@months and year(Checkupdate)=@years group by PatientId,PatientName,Treatment,CompanyPayAmt 
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetPatientbyCompanyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_GetPatientbyCompanyId](@CompanyId int)
as Begin
select Id,(RegNo +'_'+FirstName+'_'+LastName) as PatientName from PatientMst where CompanyId=@CompanyId
End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPatientMstbyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                 create procedure [dbo].[usp_GetPatientMstbyId](@PatientId int)as
				 Begin
				 select * from PatientMst where Id=@PatientId
				 End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetPatientPreviousCompanyMstbyPatientId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_GetPatientPreviousCompanyMstbyPatientId](@PatientId int)
as Begin
select Id,PatientId,RegNo,NameOfCompany,NoOfyrs,NatureOfJob,AnyOccupationalHealthAilments from PatientPreviousCompanyMst where PatientId=@PatientId
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetPatientPreviousCompanyMstbyPatientId1]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   Procedure [dbo].[usp_GetPatientPreviousCompanyMstbyPatientId1](@PatientId int)
as Begin
select Id,PatientId,RegNo,NameOfCompany as'Name Of Company',NoOfyrs as 'No. Of Years',NatureOfJob as 'Nature Of Job',AnyOccupationalHealthAilments as'Any Occupational  Health Aliments' from PatientPreviousCompanyMst where PatientId=@PatientId
End



GO
/****** Object:  StoredProcedure [dbo].[usp_GetSystemExaminationPatientMstbyPatientId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[usp_GetSystemExaminationPatientMstbyPatientId](@PatientId int)
as Begin
select * from SystemExaminationPatientMst where PatientId=@PatientId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetTestCategoryMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_GetTestCategoryMst]
as
Begin
select Id,TestCategory,Cost,UserId from TestCategoryMst
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetTestCategoryMstbyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetTestCategoryMstbyId](@testId int)
as
Begin
select * from TestCategoryMst where Id=@testId
End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTestMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   procedure [dbo].[usp_GetTestMst](@CompanyId int)
as
Begin
select t1.Id,t1.PatientId,t1.CompanyId,t2.TestCategory,t1.Cost from TestMst t1,TestCategoryMst t2 where t1.TestName=t2.Id and t1.CompanyId=@CompanyId 
End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetTestmstbyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_GetTestmstbyId](@Id int)
as
Begin
select * from TestMst where Id=@Id
End

GO
/****** Object:  StoredProcedure [dbo].[usp_gettotalamtbycompany]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_gettotalamtbycompany](@companyId int,@months int,@years int)
 as begin
 Declare @TotalAmt Decimal(10,2)
 Declare @Mon int
 Declare @Yrs int
 Declare @TotalNoEmployee int
 
 Begin
 If @months>0 and @years>0
 Begin
 select @TotalNoEmployee=count(distinct(PatientId)),@TotalAmt=sum(Convert(Decimal(10,2),CompanyPayAmt)) from PatientCheckupMst where CompanyId=@companyId and month(Checkupdate)=@months and year(Checkupdate)=@years
 End
 If @years>0
 Begin
  select @TotalNoEmployee=count(distinct(PatientId)),@TotalAmt=sum(Convert(Decimal(10,2),CompanyPayAmt))  from PatientCheckupMst where CompanyId=@companyId and year(Checkupdate)=@years
  End
  Else
  Begin
  select @TotalNoEmployee=count(distinct(PatientId)),@TotalAmt=sum(Convert(Decimal(10,2),CompanyPayAmt))  from PatientCheckupMst where CompanyId=@companyId and year(Checkupdate)=year(GETDATE())
  End
  End 
  select @TotalNoEmployee 'Total_No_Employees',@TotalAmt'Total_Amount'
  End

GO
/****** Object:  StoredProcedure [dbo].[usp_GetTreatmentMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE   procedure [dbo].[usp_GetTreatmentMst] 
 as 
 Begin
 select T.Id,T.CompanyId,T.EmployeeId,c.CompanyName,p.FirstName +' '+p.LastName 'Employee' ,T.Date,T.Description,T.Amount from TreatmentMst T,CompanyMst c,PatientMst p where T.CompanyId=c.Id and T.EmployeeId=p.Id
 End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTreatmentMstBycompanyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE   procedure [dbo].[usp_GetTreatmentMstBycompanyId](@CompanyId int,@Date date) 
 as 
 Begin
 --select * from TreatmentMst where CompanyId=@CompanyId and Date=@Date
 select T.Id,T.CompanyId,T.EmployeeId,c.CompanyName,p.FirstName +' '+p.LastName 'Employee' ,T.Date,T.Description,T.Amount from TreatmentMst T,CompanyMst c,PatientMst p where T.CompanyId=c.Id and T.EmployeeId=p.Id and T.CompanyId=@CompanyId and T.Date=@Date
 End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTreatmentMstById]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[usp_GetTreatmentMstById](@Id int) 
 as 
 Begin
 select * from TreatmentMst where Id=@Id
 End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTreatmentMstfordetail]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE     procedure [dbo].[usp_GetTreatmentMstfordetail](@CompanyId int,@Date int,@year int) 
 as 
 Begin
 --Select * from TreatmentMst
 select T.Id,T.CompanyId,T.EmployeeId,c.CompanyName,p.FirstName +' '+p.LastName 'Employee' ,T.Date,T.Description,T.Amount from TreatmentMst T,CompanyMst c,PatientMst p where T.CompanyId=c.Id and T.EmployeeId=p.Id and T.CompanyId=@CompanyId and Month(T.Date)=@Date and year(T.Date)=@year

-- select T.Id,T.CompanyId,T.EmployeeId,c.CompanyName,p.FirstName +' '+p.LastName 'Employee' ,T.Date,T.Description,T.Amount from TreatmentMst T,CompanyMst c,PatientMst p where T.CompanyId=c.Id and T.EmployeeId=p.Id and T.CompanyId=@CompanyId and T.Date=@Date

 End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetVisitingMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_GetVisitingMst]
as
Begin
select * from VisitingMst
 End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetVisitingMstById]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetVisitingMstById](@Id int)
as
Begin
select Id,CONVERT(DATE,VisitDate) as 'VisitDate',NoofDays,CandidateName,Description,Amount,CompanyId,CONVERT(DATE,BillDate) as 'BillDate',BillNo from VisitingMst where Id=@Id
 End
GO
/****** Object:  StoredProcedure [dbo].[usp_GetVisitInvoice]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[usp_GetVisitInvoice](@Id int)
as 
Begin
    SELECT 
      Id,VisitDate,CandidateName 'Candiddate Name',Description,Amount from VisitingMst
WHERE 
    Id = @Id

End
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCompanyMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE   procedure [dbo].[usp_InsertCompanyMst] 
@UserId int, 
@CompanyName nvarchar(50),
@Address nvarchar(100),
@Country nvarchar(50),
@State nvarchar(50),
@city nvarchar(50),
@zone nvarchar(50),
@Pincode nvarchar(50),
@Website nvarchar(50),
@EmailId nvarchar(50),
@Fax nvarchar(50)
,@ContactName nvarchar(50),
@ContactNumber nvarchar(50),
@Designation nvarchar(50),
@ContactName1 nvarchar(50),
@ContactNumber1 nvarchar(50),
@Designation1 nvarchar(50),
@PayingAmt nvarchar(20),
@Vat nvarchar(50),
@GSTIN nvarchar(200),
@ServiceType nvarchar(50),
@Panno nvarchar(100)
as 
begin
If Exists(select * from CompanyMst where CompanyName=@CompanyName and EmailId=@EmailId  and ContactName=@ContactName and zone=@zone and City=@city)
Begin
select 0
End Else
Begin
Declare @Id int
 select @Id=count(Id)+1  from CompanyMst
insert into CompanyMst(Id,UserId,CompanyName,Address,Country,State,city,zone,Pincode,Website,EmailId,Fax,ContactName,ContactNumber,Designation,ContactName1,ContactNumber1,Designation1,PayingAmt,Vat,GSTIN,ServiceType,Panno, InsertDate, Status) 
values
(@Id,@UserId, @CompanyName,@Address,@Country,@State,@city,@zone,@Pincode,@Website,@EmailId,@Fax,@ContactName,@ContactNumber,@Designation,@ContactName1,@ContactNumber1,@Designation1,@PayingAmt,@Vat,@GSTIN,@ServiceType,@Panno,CURRENT_TIMESTAMP,'1');

select @Id
End
End




GO
/****** Object:  StoredProcedure [dbo].[usp_InsertGeneralExaminationPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_InsertGeneralExaminationPatientMst]
(@PatientId int,@RegNo nvarchar(50),@Height nvarchar(50),@Weight nvarchar(50),
 @Pluse nvarchar(50), @BP nvarchar(50), @TempInF nvarchar(50), @Respiration nvarchar(50),
 @Built nvarchar(50),@Nutrition nvarchar(50),@Nails nvarchar(50),@Teeth nvarchar(50),
 @Gums nvarchar(50),@OralHygene nvarchar(50),@LymphNodes nvarchar(50),@Eyes nvarchar(50),@Spine nvarchar(50),
 @Tongue nvarchar(50),@Ent nvarchar(50),@BonesJoints nvarchar(50),@Skin nvarchar(50),@HearingR nvarchar(50),
 @HearingL nvarchar(50),@EyesVisionR nvarchar(50),@EyesVisionL nvarchar(50),@ColourVision nvarchar(50))
as
Begin
if Exists(select * from GeneralExaminationPatientMst where RegNo=@RegNo  and PatientId=@PatientId)
Begin
select 0
End
Else
Begin
Declare @Id int
select @Id=Count(Id)+1 from GeneralExaminationPatientMst
insert into GeneralExaminationPatientMst(Id,PatientId,RegNo,Height,Weight,Pluse,BP,TempInF,Respiration,Built,Nutrition,Nails,Teeth,Gums,OralHygene,LymphNodes,Eyes,Spine,Tongue,Ent,BonesJoints,Skin,HearingR,HearingL,EyesVisionR,EyesVisionL,ColourVision,InsertDate,Status) values
                        (@Id,@PatientId,@RegNo,@Height,@Weight, @Pluse, @BP, @TempInF, @Respiration,@Built,@Nutrition,@Nails,@Teeth,@Gums,@OralHygene,@LymphNodes,@Eyes,@Spine,@Tongue,@Ent,@BonesJoints,@Skin,@HearingR,@HearingL,@EyesVisionR,@EyesVisionL,@ColourVision,Current_TimeStamp,'1')

						select @Id
End
						End

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertPatientCheckupMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_InsertPatientCheckupMst]
 (@UserId int,@PatientId int,@RegNo nvarchar(50),@PatientName nvarchar(50),@CompanyId int,@CompanyName nvarchar(50),@ContactName nvarchar(50),
 @DoctorId int,@DoctorName nvarchar(50),@Treatment nvarchar(200),@Checkupdate datetime,@NextCheckupdate datetime,@CompanyPayAmt nvarchar(50),@PatientPayAmt nvarchar(50))
 as Begin
 If Exists(select * from PatientCheckupMst where PatientId=@PatientId and DoctorId=@DoctorId and convert(date,Checkupdate)=convert(date,@Checkupdate)and convert(date,NextCheckupdate)=convert(date,@NextCheckupdate) and CompanyId=@CompanyId)
 Begin
 select 0
 End 
 Else
 Begin
 Declare @Id int
 select @Id=count(Id)+1 from PatientCheckupMst
insert into PatientCheckupMst(Id,UserId,PatientId,RegNo,PatientName,CompanyId,CompanyName,ContactName,DoctorId,DoctorName,Treatment,Checkupdate,NextCheckupdate,CompanyPayAmt,InsertDate,Status) values
               (@Id,@UserId,@PatientId,@RegNo,@PatientName,@CompanyId,@CompanyName,@ContactName,@DoctorId,@DoctorName,@Treatment,@Checkupdate,@NextCheckupdate,@CompanyPayAmt,current_Timestamp,'1')
			   select @Id
			   End
			   End


GO
/****** Object:  StoredProcedure [dbo].[usp_insertpatientformimage2]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_insertpatientformimage2](@PatientId int,@form2Image nvarchar(500))
as
Begin
update PatientformImage set formImage2=@form2Image where PatientId=@PatientId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_InsertPatientMst](
 @UserId int,@DoctorId int,@CompanyId int,@DateOn datetime,@Title nvarchar(20),@FirstName nvarchar(50),@LastName nvarchar(50),
 @DOB datetime,@Gender nvarchar(50),
 @Age decimal,@Mariatal_Status nvarchar(50),@Photo nvarchar(100),@IDMark nvarchar(50)
 ,@Diet nvarchar(50),@MobileNumber nvarchar(50),@Address nvarchar(50),@PersonalHabbits nvarchar(50),@DominantHand nvarchar(50),
 @Immunisation nvarchar(50),@FamilyHistory nvarchar(50),@PersonalHistory nvarchar(50),@PastHistory nvarchar(50),
 @smokehabbitday nvarchar(50),@smokehabbit nvarchar(50),@smokehabbityear nvarchar(50),@MenstrualCycle nvarchar(50),@OtherComplaints nvarchar(50),
 @PresentJobDesc nvarchar(50))
 AS
 Begin
 If Exists(select * from PatientMst where DoctorId=@DoctorId and CompanyId=@CompanyId and FirstName=@FirstName and LastName=@LastName and  DOB=@DOB)
 Begin
 select 0
 End 
 Else
 Begin
 Declare @Id int
 Declare @RegNo nvarchar(50)
  select @Id=count(Id)+1 from PatientMst
  select @RegNo= convert(varchar(8), Day(@DateOn))+substring(@FirstName,1,1)+substring(@LastName,1,1)+convert(varchar(8), month(@DOB))+convert(varchar(8),right(year(@DateOn),2)) 
  insert into PatientMst (Id,RegNo, UserId,DoctorId,CompanyId,DateOn,Title,FirstName,LastName,
 DOB,Gender, Age,Mariatal_Status,Photo,IDMark,Diet,MobileNumber,Address,PersonalHabbits,DominantHand,
 Immunisation,FamilyHistory,PersonalHistory,PastHistory,smokehabbitday,smokehabbit,smokehabbityear,MenstrualCycle,OtherComplaints,
 PresentJobDesc,InsertDate,Status) values
 (@Id,@RegNo, @UserId,@DoctorId,@CompanyId,@DateOn,@Title,@FirstName,@LastName,
 @DOB,@Gender,@Age,@Mariatal_Status,@Photo,@IDMark,@Diet,@MobileNumber,@Address,@PersonalHabbits,@DominantHand,
 @Immunisation,@FamilyHistory,@PersonalHistory,@PastHistory,@smokehabbitday,@smokehabbit,@smokehabbityear,@MenstrualCycle,@OtherComplaints,
 @PresentJobDesc,current_timestamp,'1')
  
  select @Id
  End
  End


GO
/****** Object:  StoredProcedure [dbo].[usp_InsertPatientPreviousCompanyMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create Procedure [dbo].[usp_InsertPatientPreviousCompanyMst]
(@PatientId int,@NameOfCompany nvarchar(50),@NoOfyrs int,@NatureOfJob nvarchar(50),@AnyOccupationalHealthAilments nvarchar(50)
)As
Begin
If Exists(select *  from PatientPreviousCompanyMst where PatientId=@PatientId and NameOfCompany=@NameOfCompany )
Begin
select 0
End
Else
Begin
Declare @Id int
Declare @RegNo nvarchar(50)
select @RegNo=RegNo from PatientMst where Id=@PatientId
Select @Id=count(Id)+1 from PatientPreviousCompanyMst
insert into PatientPreviousCompanyMst(Id,PatientId,RegNo,NameOfCompany,NoOfyrs,NatureOfJob,AnyOccupationalHealthAilments,
InsertDate,Status) values
         (@Id,@PatientId,@RegNo,@NameOfCompany,@NoOfyrs,@NatureOfJob,@AnyOccupationalHealthAilments,
		Current_Timestamp,'1')

 select @Id
 End
 End



GO
/****** Object:  StoredProcedure [dbo].[usp_InsertSystemExaminationPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_InsertSystemExaminationPatientMst]
(
@PatientId int,@RegNo nvarchar(50),@Cardio_HeartSound nvarchar(50),@Cardio_Murmur nvarchar(50),
@Respir_ChestMovements nvarchar(50),@Respir_Trachea nvarchar(50),@Respir_BreathSounds nvarchar(50),@Respir_AdventitiousSounds nvarchar(50),
@Gastrointestional_Liver nvarchar(50),@Gastrointestional_Spleen nvarchar(50),@CentralNervous_HigherFunction nvarchar(50),
@CentralNervous_SensorySystem nvarchar(50),@CentralNervous_MotorSystem nvarchar(50),@GenitoUrinarySystem nvarchar(50)
)
as Begin
If Exists(select * from SystemExaminationPatientMst where RegNo=@RegNo and PatientId=@PatientId)
Begin
select 0
End
Else
Begin
Declare @Id int 
select @Id=Count(Id)+1 from SystemExaminationPatientMst
insert into SystemExaminationPatientMst(Id,PatientId,RegNo,Cardio_HeartSound,Cardio_Murmur,Respir_ChestMovements,Respir_Trachea,Respir_BreathSounds,Respir_AdventitiousSounds,Gastrointestional_Liver,Gastrointestional_Spleen,CentralNervous_HigherFunction,CentralNervous_SensorySystem,CentralNervous_MotorSystem,GenitoUrinarySystem,InsertDate,Status) values
            (@Id,@PatientId,@RegNo,@Cardio_HeartSound,@Cardio_Murmur,@Respir_ChestMovements,@Respir_Trachea,@Respir_BreathSounds,@Respir_AdventitiousSounds,@Gastrointestional_Liver,@Gastrointestional_Spleen,@CentralNervous_HigherFunction,@CentralNervous_SensorySystem,@CentralNervous_MotorSystem,@GenitoUrinarySystem,Current_Timestamp,'1')
			select @Id
			End
End

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertTestCategoryMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[usp_InsertTestCategoryMst](@TestCategory nvarchar(100),@Cost nvarchar(50),@UserId int)
as
Begin
if Exists(select * from TestCategoryMst where TestCategory=@TestCategory)
Begin
select 0
End
Else
Begin
Declare @Id int
select @Id=count(Id)+1 from TestCategoryMst
insert into TestCategoryMst(Id,TestCategory,Cost,UserId,InsertedDate,Status) values(@Id,@TestCategory,@Cost,@UserId,CURRENT_TIMESTAMP,'1')

End
select @Id
End


GO
/****** Object:  StoredProcedure [dbo].[usp_InsertTestMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE     procedure [dbo].[usp_InsertTestMst](@UserId int,
	@CompanyId int,
	@PatientId int,
	@Date datetime,
	@TestName nvarchar (50),
	@Cost nvarchar(50)
)
as
Begin
if Exists(select * from TestMst where CompanyId=@CompanyId and PatientId=@PatientId and convert(Date,Date)=convert(Date,@Date))
Begin
select 0
End
Else
Begin
Declare @Id int

select @Id=count(Id)+1 from TestMst

insert into TestMst(Id,UserId,CompanyId,PatientId,Date,TestName,Cost,InsertedDate,Status) values(@Id,@UserId,@CompanyId,@PatientId,@Date,@TestName,@Cost,CURRENT_TIMESTAMP,'1')
select @Id
End
End

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertTreatmentMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[usp_InsertTreatmentMst] 
( @CompanyId int
           ,@EmployeeId int
           ,@Date date
           ,@Description nvarchar(500)
           ,@Amount nvarchar(50)
           ,@UserId int 
          )
		  as
		  Begin
		--  if Exists(Select * from  TreamentMst where CompanyId=@CompanyId and Employee)
	Declare	@Id int
		Select @Id=Count(*)+1 from TreatmentMst 

INSERT INTO TreatmentMst
           ([Id]
           ,[CompanyId]
           ,[EmployeeId]
           ,[Date]
           ,[Description]
           ,[Amount]
           ,[UserId]
           )
     VALUES
           (@Id,
		   @CompanyId 
           ,@EmployeeId 
           ,@Date 
           ,@Description
           ,@Amount
           ,@UserId)
  
  End
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertUserMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_InsertUserMst]
(@RoleId int,@Name nvarchar(50), @UserName nvarchar(50), @Password nvarchar(50), @Mobile nvarchar(50),@EmailId nvarchar(50),@Address nvarchar(200),@Pincode nvarchar(50))
as
Begin
If Exists(select * from UserMst where RoleId=@RoleId and Name=@Name and UserName=@UserName  and Password=@Password and EmailId=@EmailId )
Begin
select 0
End
Else
Begin
Declare @Id int
select @Id=count(Id)+1 from UserMst
Declare @RoleName1 nvarchar(10)
select @RoleName1=RoleName from RoleMst where RoleId=@RoleId
insert into UserMst(Id,RoleId, RoleName, Name, UserName,  Password,  Mobile,EmailId, Address,Pincode, InsertedDate,Status) values
                            (@Id,@RoleId, @RoleName1, @Name, @UserName, @Password, @Mobile,@EmailId,@Address,@Pincode,current_timestamp,'1')

select @Id
End
End

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertVisitingMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertVisitingMst](@VisitDate date
           ,@NoofDays int
           , @CandidateName nvarchar(100)
           ,@Description nvarchar(500)
           ,@Amount nvarchar(50)
           ,@CompanyId int
           ,@BillDate date
           ,@BillNo int)

as
Begin
 Declare @Id int
 select @Id=count(*)+1 from VisitingMst 

INSERT INTO [dbo].[VisitingMst]
           ([Id]
           ,[VisitDate]
           ,[NoofDays]
           ,[CandidateName]
           ,[Description]
           ,[Amount]
           ,[CompanyId]
           ,[BillDate]
           ,[BillNo])
     VALUES
           (@Id
           ,@VisitDate
           ,@NoofDays
           ,@CandidateName
           ,@Description
           ,@Amount
           ,@CompanyId
           ,@BillDate
           ,@BillNo)


		   select 1
		   End
GO
/****** Object:  StoredProcedure [dbo].[usp_PatientfrmImage]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[usp_PatientfrmImage](@PatientId int,
@form1Image nvarchar(500),
@form2Image nvarchar(500)
)
as
Begin
if Exists(select * from PatientformImage where PatientId=@PatientId)
begin
 if exists(select * from PatientformImage where PatientId=@PatientId and formImage1=@form1Image)
 begin
 update PatientformImage set formImage1=@form1Image where PatientId=@PatientId 
 End
 if exists(select * from PatientformImage where PatientId=@PatientId and formImage2=@form2Image)
 begin
 update PatientformImage set formImage2=@form2Image where PatientId=@PatientId 
 End
select 0
end
Else
Begin
insert into PatientformImage (PatientId,formImage1,formImage2) values(@PatientId,@form1Image,@form2Image)
select  @PatientId
End

End


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectByIdUserMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_SelectByIdUserMst](@RoleId int)
As 
Begin 
select * from UserMst where RoleId=@RoleId
End 

GO
/****** Object:  StoredProcedure [dbo].[usp_SelecttestMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_SelecttestMst]
as
Begin
select * from TestMst
End

GO
/****** Object:  StoredProcedure [dbo].[usp_SelecttestMstbyPatientId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_SelecttestMstbyPatientId](@PatientId int )
as
Begin
select * from TestMst where PatientId=@PatientId
End

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUserMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_SelectUserMst] 
As 
Begin 
select * from UserMst
End 

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUserMstbyUserName]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[usp_SelectUserMstbyUserName]
(@UserName nvarchar(50),
@Password nvarchar(50)
)
as
Begin
select Id,UserName from UserMst where UserName=@UserName and Password=@Password

End
GO
/****** Object:  StoredProcedure [dbo].[usp_UermstbyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[usp_UermstbyId](@UserId int)
as Begin
Select * from UserMst where Id=@UserId
End
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCompanyMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE   procedure [dbo].[usp_UpdateCompanyMst](@companyId int,@UserId int,@CompanyName nvarchar(50),@Address nvarchar(200),@Country nvarchar(50),@State nvarchar(50),@city nvarchar(50),@zone nvarchar(50),@Pincode nvarchar(50),@EmailId nvarchar(50),@Website nvarchar(50),@ContactName nvarchar(50),@ContactNumber nvarchar(50),@Designation nvarchar(50),@ContactName1 nvarchar(50),@ContactNumber1 nvarchar(50),@Designation1 nvarchar(50),@Fax nvarchar(50),@PayingAmt nvarchar(50),@Vat nvarchar(50),@GSTIN nvarchar(200),@ServiceType nvarchar(50),@Panno nvarchar(100))
as
Begin
update CompanyMst set UserId=@UserId, CompanyName=@CompanyName, Address=@Address,Country=@Country,State=@State,city=@city,zone=@zone,Pincode=@Pincode,Website=@Website,EmailId=@EmailId,Fax=@Fax,ContactName=@ContactName,ContactNumber=@ContactNumber,Designation=@Designation,ContactName1=@ContactName1,ContactNumber1=@ContactNumber1,Designation1=@Designation1,PayingAmt=@PayingAmt,Vat=@Vat,GSTIN=@GSTIN,ServiceType=@ServiceType,Panno=@Panno,UpdatDate=CURRENT_TIMESTAMP, Status='2' where Id=@companyId
select 1
End



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateGeneralExaminationPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_UpdateGeneralExaminationPatientMst]
(@Id int,@PatientId int,@RegNo nvarchar(50),@Height nvarchar(50),@Weight nvarchar(50),
 @Pluse nvarchar(50), @BP nvarchar(50), @TempInF nvarchar(50), @Respiration nvarchar(50),
 @Built nvarchar(50),@Nutrition nvarchar(50),@Nails nvarchar(50),@Teeth nvarchar(50),
 @Gums nvarchar(50),@OralHygene nvarchar(50),@LymphNodes nvarchar(50),@Eyes nvarchar(50),@Spine nvarchar(50),
 @Tongue nvarchar(50),@Ent nvarchar(50),@BonesJoints nvarchar(50),@Skin nvarchar(50),@HearingR nvarchar(50),
 @HearingL nvarchar(50),@EyesVisionR nvarchar(50),@EyesVisionL nvarchar(50),@ColourVision nvarchar(50))
as
Begin
update GeneralExaminationPatientMst set RegNo=@RegNo,Height=@Height,Weight=@Weight,Pluse=@Pluse,BP=@BP,TempInF=@TempInF,
Respiration= @Respiration,Built=@Built,Nutrition=@Nutrition,Nails=@Nails,Teeth=@Teeth,Gums=@Gums,OralHygene=@OralHygene,
LymphNodes=@LymphNodes,Eyes=@Eyes,Spine=@Spine,Tongue=@Tongue,Ent=@Ent,BonesJoints=@BonesJoints,Skin=@Skin,
HearingR=@HearingR,HearingL=@HearingL,EyesVisionR=@EyesVisionR,EyesVisionL=@EyesVisionL,ColourVision=@ColourVision,UpdateDate=Current_Timestamp,Status='2'
 where Id=@Id and PatientId=@PatientId
select @Id
End

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateInvestigationRemarkPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_UpdateInvestigationRemarkPatientMst]
(@Id int,
@PatientId int,@RegNo nvarchar(50),@BloodReport nvarchar(50),@UrineReport nvarchar(50),@XRayChestReport nvarchar(50),
@PFT nvarchar(50),@ECG nvarchar(50),@Audiometry nvarchar(50),@Spirometry nvarchar(50),@FitnessCertificate nvarchar(50),@BloodReportAttached nvarchar(300),@UrineReportAttached nvarchar(300),@XRayChestReportAttached nvarchar(300),
@PFTAttached nvarchar(300),@ECGAttached nvarchar(300),@AudiometryAttached nvarchar(300),@SpirometryAttached nvarchar(300),@FitnessCertificateAttached nvarchar(300),@Advise nvarchar(200),@Remarks nvarchar(200),@DoctorsRemark nvarchar(50)
)
as Begin
update InvestigationRemarkPatientMst set RegNo=@RegNo,BloodReport=@BloodReport,UrineReport=@UrineReport,XRayChestReport=@XRayChestReport,
PFT=@PFT,ECG=@ECG,Audiometry=@Audiometry,Spirometry=@Spirometry,FitnessCertificate=@FitnessCertificate,BloodReportAttached=@BloodReportAttached,UrineReportAttached=@UrineReportAttached,
XRayChestReportAttached=@XRayChestReportAttached,
PFTAttached=@PFTAttached,ECGAttached=@ECGAttached,AudiometryAttached=@AudiometryAttached,SpirometryAttached=@SpirometryAttached,FitnessCertificateAttached=@FitnessCertificateAttached,Advise=@Advise,Remarks=@Remarks,DoctorsRemark=@DoctorsRemark,UpdateDate=Current_Timestamp,Status='2'
where Id=@Id and PatientId=@PatientId
             
select @Id

End

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



 CREATE Procedure [dbo].[usp_UpdatePatientMst](@PatientId int,@RegNo nvarchar(50),
 @UserId int,@DoctorId int,@CompanyId int,@DateOn datetime,@FirstName nvarchar(50),@LastName nvarchar(50),
 @DOB datetime,@Gender nvarchar(50),
 @Age decimal,@Mariatal_Status nvarchar(50),@Photo nvarchar(100),@IDMark nvarchar(50)
 ,@Diet nvarchar(50),@MobileNumber nvarchar(50),@Address nvarchar(50),@PersonalHabbits nvarchar(50),@DominantHand nvarchar(50),
 @Immunisation nvarchar(50),@FamilyHistory nvarchar(50),@PersonalHistory nvarchar(50),@PastHistory nvarchar(50),
 @smokehabbitday nvarchar(50),@smokehabbit nvarchar(50),@smokehabbityear nvarchar(50),@MenstrualCycle nvarchar(50),@OtherComplaints nvarchar(50),
 @PresentJobDesc nvarchar(50))
 AS
 Begin
 update PatientMst set UserId=@UserId,DoctorId=@DoctorId,CompanyId=@CompanyId,RegNo=@RegNo,
 DateOn=@DateOn,FirstName=@FirstName,LastName=@LastName,DOB=@DOB,Gender=@Gender,Age=@Age,
 Mariatal_Status=@Mariatal_Status,Photo=@Photo,IDMark=@IDMark,Diet=@Diet,MobileNumber=@MobileNumber,
 Address=@Address,PersonalHabbits=@PersonalHabbits,DominantHand=@DominantHand,Immunisation=@Immunisation,FamilyHistory=@FamilyHistory,PersonalHistory=@PersonalHistory,PastHistory=@PastHistory,smokehabbitday=@smokehabbitday,smokehabbit=@smokehabbit,smokehabbityear=@smokehabbityear,MenstrualCycle=@MenstrualCycle,OtherComplaints=@OtherComplaints,PresentJobDesc=@PresentJobDesc,UpdatedDate=Current_Timestamp,Status='2'
  where Id=@PatientId
  select @PatientId
  
  End



GO
/****** Object:  StoredProcedure [dbo].[usp_UpdatePatientPreviousCompanyMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[usp_UpdatePatientPreviousCompanyMst]
(@Id int,@PatientId int,@RegNo nvarchar(50),@NameOfCompany nvarchar(50),@NoOfyrs int,@NatureOfJob nvarchar(50),@AnyOccupationalHealthAilments nvarchar(50)
)As
Begin
if(@Id=0)
Begin
exec [dbo].[usp_InsertPatientPreviousCompanyMst] @PatientId,@NameOfCompany,@NoOfyrs,@NatureOfJob,@AnyOccupationalHealthAilments
End
 Else
Begin
update PatientPreviousCompanyMst set RegNo=@RegNo,NameOfCompany=@NameOfCompany,NoOfyrs=@NoOfyrs,NatureOfJob=@NatureOfJob,AnyOccupationalHealthAilments=@AnyOccupationalHealthAilments,
UpdateDate=Current_Timestamp,Status='2'
where Id=@Id and PatientId=@PatientId
End
 select @Id
 
 End




GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateSystemExaminationPatientMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpdateSystemExaminationPatientMst]
(@Id int,
@PatientId int,@RegNo nvarchar(50),@Cardio_HeartSound nvarchar(50),@Cardio_Murmur nvarchar(50),
@Respir_ChestMovements nvarchar(50),@Respir_Trachea nvarchar(50),@Respir_BreathSounds nvarchar(50),@Respir_AdventitiousSounds nvarchar(50),
@Gastrointestional_Liver nvarchar(50),@Gastrointestional_Spleen nvarchar(50),@CentralNervous_HigherFunction nvarchar(50),
@CentralNervous_SensorySystem nvarchar(50),@CentralNervous_MotorSystem nvarchar(50),@GenitoUrinarySystem nvarchar(50)
)
as Begin
update SystemExaminationPatientMst set RegNo=@RegNo,Cardio_HeartSound=@Cardio_HeartSound,Cardio_Murmur=@Cardio_Murmur,
Respir_ChestMovements=@Respir_ChestMovements,Respir_Trachea=@Respir_Trachea,Respir_BreathSounds=@Respir_BreathSounds,
Respir_AdventitiousSounds=@Respir_AdventitiousSounds,Gastrointestional_Liver=@Gastrointestional_Liver,
Gastrointestional_Spleen=@Gastrointestional_Spleen,CentralNervous_HigherFunction=@CentralNervous_HigherFunction,
CentralNervous_SensorySystem=@CentralNervous_SensorySystem,CentralNervous_MotorSystem=@CentralNervous_MotorSystem,GenitoUrinarySystem=@GenitoUrinarySystem,UpdateDate=Current_Timestamp,Status='2'
where Id=@Id and PatientId=@PatientId
			
select @Id
			
End

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTestCategoryMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_UpdateTestCategoryMst](@Id int,@TestCategory nvarchar(100),@Cost nvarchar(50),@UserId int)
as
Begin
update TestCategoryMst set TestCategory=@TestCategory,Cost=@Cost,UserId=@UserId,UpdatedDate=CURRENT_TIMESTAMP,Status='2' where Id=@Id

select @Id
End

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTestMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE   procedure [dbo].[usp_UpdateTestMst](@Id int,
	@CompanyId int,
	@PatientId int,
	@Date datetime,
	@TestName nvarchar (50),
	@Cost nvarchar(50)
)
as
Begin
update TestMst set TestName=@TestName,Cost=@Cost,Date=@Date,UpdatedDate=CURRENT_TIMESTAMP,Status='2' where Id=@Id
select @Id
End


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTreatmentMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[usp_UpdateTreatmentMst] 
( @Id int,@CompanyId int
           ,@EmployeeId int
           ,@Date date
           ,@Description nvarchar(500)
           ,@Amount nvarchar(50)
           ,@UserId int 
          )
		  as
		  Begin
		--  if Exists(Select * from  TreamentMst where CompanyId=@CompanyId and Employee)
	update TreatmentMst
           set 
           [CompanyId]=@CompanyId
           ,[EmployeeId]=@EmployeeId
           ,[Date]=@Date
           ,[Description]=@Description
           ,[Amount]=@Amount
           ,[UserId]=@UserId
           
     where [Id]=@Id
	 select 1
  End
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateUserMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_UpdateUserMst]
(
@RoleId int,
@RoleName nvarchar(50),
@Name nvarchar(50),
@UserName nvarchar(50),
@Password nvarchar(50),
@Mobile nvarchar(50),
@Address nvarchar(200),
@UpdatedDate datetime,
@Status nvarchar(10))
As 
Begin 
UPDATE UserMst 
SET 
RoleName=@RoleName,
Name=@Name,
UserName=@UserName,
Password=@Password,
Mobile=@Mobile,
Address=@Address,
UpdatedDate=@UpdatedDate,
Status=@Status
WHERE RoleId=@RoleId;

Select 1
End 

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateUserMstbyId]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[usp_UpdateUserMstbyId](@UserId int,@RoleId int,@Name nvarchar(50),@UserName nvarchar(50),@Password nvarchar(50),@Mobile nvarchar(50),@EmailId nvarchar(50),@Address nvarchar(200),@Pincode nvarchar(50))
as
Begin
Declare @RoleName nvarchar(50)
select @RoleName=RoleName from RoleMst where RoleId=@RoleId
update UserMst set RoleId=@RoleId, RoleName=@RoleName, Name=@Name,UserName=@UserName,Password=@Password,Mobile=@Mobile,EmailId=@EmailId, Address=@Address,Pincode=@Pincode, UpdatedDate=Current_TimeStamp, Status=2 where Id=@UserId
select 1
End


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateVisitingMst]    Script Date: 10-01-2025 19:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpdateVisitingMst](@Id int,@VisitDate date
           ,@NoofDays int
           , @CandidateName nvarchar(100)
           ,@Description nvarchar(500)
           ,@Amount nvarchar(50)
           ,@CompanyId int
           ,@BillDate date
           ,@BillNo int)

as
Begin

UPDATE [dbo].[VisitingMst]
   SET  
      [VisitDate] = @VisitDate
      ,[NoofDays] = @NoofDays
      ,[CandidateName] = @CandidateName
      ,[Description] = @Description
      ,[Amount] = @Amount
      ,[CompanyId] = @CompanyId
      ,[BillDate] = @BillDate
      ,[BillNo] = @BillNo
 WHERE [Id] = @Id 
 select 1
 End
GO
