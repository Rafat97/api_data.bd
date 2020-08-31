﻿CREATE TABLE [dbo].[BoardResults] (
    [BoardResultId] [int] NOT NULL IDENTITY,
    [Year] [nvarchar](max) NOT NULL,
    [ResultType] [nvarchar](max) NOT NULL,
    [ExamAttendence] [nvarchar](max) NOT NULL,
    [GpaFiveStudentNumber] [nvarchar](max) NOT NULL,
    [FailStudentNumber] [nvarchar](max) NOT NULL,
    [InstituitionId] [int],
    CONSTRAINT [PK_dbo.BoardResults] PRIMARY KEY ([BoardResultId])
)
CREATE INDEX [IX_InstituitionId] ON [dbo].[BoardResults]([InstituitionId])
CREATE TABLE [dbo].[Instituitions] (
    [InstituitionId] [int] NOT NULL IDENTITY,
    [InstituitionName] [nvarchar](max) NOT NULL,
    [InstituitionEstablishment] [nvarchar](max) NOT NULL,
    [InstituitionType] [nvarchar](max) NOT NULL,
    [InstituitionEiin] [int] NOT NULL,
    [InstituitionPhoneNumber] [nvarchar](max),
    [InstituitionManagementType] [nvarchar](max) NOT NULL,
    [InstituitionEducationLevel] [nvarchar](max) NOT NULL,
    [InstituitionAddressId] [int],
    CONSTRAINT [PK_dbo.Instituitions] PRIMARY KEY ([InstituitionId])
)
CREATE INDEX [IX_InstituitionAddressId] ON [dbo].[Instituitions]([InstituitionAddressId])
CREATE TABLE [dbo].[InstituitionsAddresses] (
    [InstituitionAddressId] [int] NOT NULL IDENTITY,
    [InstituitionAddressUnion] [nvarchar](max) NOT NULL,
    [InstituitionAddressThana] [nvarchar](max) NOT NULL,
    [InstituitionAddressDivision] [nvarchar](max) NOT NULL,
    [InstituitionAddressDistrict] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.InstituitionsAddresses] PRIMARY KEY ([InstituitionAddressId])
)
CREATE TABLE [dbo].[InstituteStatistics] (
    [InstituteStatisticsId] [int] NOT NULL IDENTITY,
    [InstituteStatisticsMaleTeacher] [nvarchar](max) NOT NULL,
    [InstituteStatisticsFemaleTeacher] [nvarchar](max) NOT NULL,
    [InstituteStatisticsYear] [nvarchar](max) NOT NULL,
    [InstituteStatisticsBoysStudent] [nvarchar](max),
    [InstituteStatisticsGirlsStudent] [nvarchar](max),
    [InstituitionId] [int],
    CONSTRAINT [PK_dbo.InstituteStatistics] PRIMARY KEY ([InstituteStatisticsId])
)
CREATE INDEX [IX_InstituitionId] ON [dbo].[InstituteStatistics]([InstituitionId])
CREATE TABLE [dbo].[OAUTH_Roles] (
    [Id] [nvarchar](128) NOT NULL,
    [Name] [nvarchar](256) NOT NULL,
    CONSTRAINT [PK_dbo.OAUTH_Roles] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[OAUTH_Roles]([Name])
CREATE TABLE [dbo].[OAUTH_UserRoles] (
    [UserId] [nvarchar](128) NOT NULL,
    [RoleId] [nvarchar](128) NOT NULL,
    CONSTRAINT [PK_dbo.OAUTH_UserRoles] PRIMARY KEY ([UserId], [RoleId])
)
CREATE INDEX [IX_UserId] ON [dbo].[OAUTH_UserRoles]([UserId])
CREATE INDEX [IX_RoleId] ON [dbo].[OAUTH_UserRoles]([RoleId])
CREATE TABLE [dbo].[Students] (
    [StudentId] [int] NOT NULL IDENTITY,
    [StudentName] [nvarchar](max),
    [StudentAge] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Students] PRIMARY KEY ([StudentId])
)
CREATE TABLE [dbo].[OAUTH_Users] (
    [Id] [nvarchar](128) NOT NULL,
    [Email] [nvarchar](256),
    [EmailConfirmed] [bit] NOT NULL,
    [PasswordHash] [nvarchar](max),
    [SecurityStamp] [nvarchar](max),
    [PhoneNumber] [nvarchar](max),
    [PhoneNumberConfirmed] [bit] NOT NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime],
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
    CONSTRAINT [PK_dbo.OAUTH_Users] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[OAUTH_Users]([UserName])
CREATE TABLE [dbo].[OAUTH_UserClaims] (
    [Id] [int] NOT NULL IDENTITY,
    [UserId] [nvarchar](128) NOT NULL,
    [ClaimType] [nvarchar](max),
    [ClaimValue] [nvarchar](max),
    CONSTRAINT [PK_dbo.OAUTH_UserClaims] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_UserId] ON [dbo].[OAUTH_UserClaims]([UserId])
CREATE TABLE [dbo].[OAUTH_UserLogins] (
    [LoginProvider] [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](128) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
    CONSTRAINT [PK_dbo.OAUTH_UserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey], [UserId])
)
CREATE INDEX [IX_UserId] ON [dbo].[OAUTH_UserLogins]([UserId])
ALTER TABLE [dbo].[BoardResults] ADD CONSTRAINT [FK_dbo.BoardResults_dbo.Instituitions_InstituitionId] FOREIGN KEY ([InstituitionId]) REFERENCES [dbo].[Instituitions] ([InstituitionId])
ALTER TABLE [dbo].[Instituitions] ADD CONSTRAINT [FK_dbo.Instituitions_dbo.InstituitionsAddresses_InstituitionAddressId] FOREIGN KEY ([InstituitionAddressId]) REFERENCES [dbo].[InstituitionsAddresses] ([InstituitionAddressId])
ALTER TABLE [dbo].[InstituteStatistics] ADD CONSTRAINT [FK_dbo.InstituteStatistics_dbo.Instituitions_InstituitionId] FOREIGN KEY ([InstituitionId]) REFERENCES [dbo].[Instituitions] ([InstituitionId])
ALTER TABLE [dbo].[OAUTH_UserRoles] ADD CONSTRAINT [FK_dbo.OAUTH_UserRoles_dbo.OAUTH_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[OAUTH_Roles] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[OAUTH_UserRoles] ADD CONSTRAINT [FK_dbo.OAUTH_UserRoles_dbo.OAUTH_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[OAUTH_Users] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[OAUTH_UserClaims] ADD CONSTRAINT [FK_dbo.OAUTH_UserClaims_dbo.OAUTH_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[OAUTH_Users] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[OAUTH_UserLogins] ADD CONSTRAINT [FK_dbo.OAUTH_UserLogins_dbo.OAUTH_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[OAUTH_Users] ([Id]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'202008300817541_InitialMigration', N'api_data_bd.Migrations.Configuration',  0x1F8B0800000000000400DD5DD96EE4B8157D0F907F10EA29093C555EA61B1DA33C03B7971E23ED056DF720793268892E0BADA5468BC746305F96877C527E21D45ADC178925C98D7E6997C8732F2F2F2FC94BEAE87FFFF9EFF2E79730709E6192FA717434DB9BEFCE1C18B9B1E747ABA3599E3DFEF061F6F34F7FFED3F2CC0B5F9C5F9B7207453954334A8F664F59B63E5C2C52F70986209D87BE9BC469FC98CDDD385C002F5EECEFEEFE7DB1B7B780086286B01C67F9258F323F84E51FE8CF933872E13ACB4170197B3048EBDFD193DB12D5B902214CD7C0854733B0F6EF3D9081FB076F5E959E39C7810F9026B730789C39208AE20C6448CFC3AF29BCCD92385ADDAED10F20B87B5D4354EE110429ACF53FDC14D76DCAEE7ED194C5A66203E5E669168786807B07B56D1674F54E169EB5B643D63B4356CE5E8B5697163C9A7D8C41E27D81691E643387967778122445599E8DE758CD1D077BBED33A05F29DE2DF8E7382CAE4093C8A609E2520D8716EF287C077FF015FEFE26F303A8AF220C0D5448AA267C40FE8A79B245EC3247BFD021F59E52FBC99B320211634468BC0AF5EB5F422CA0EF667CE1552093C04B0F50DCC2AB7599CC04F308209C8A07703B20C26A86B2F3C585A97518412FB2F0892461A724634AE66CE2578F90CA355F6743443FF9D39E7FE0BF49A5F6A0DBE463E1A86A85296E490A3A15C6AD5CE42EAF0B2CF5E40788CAC14210BB923C8FFB406E7FE331AF979D1455779F80047E88173E00723AB7011A5C84373BF7063C6E5A9AA57E0D95F950E2F0141A1F60B0CCA52E993BFAE22EE9C28714F8498F3240EBFC4010D8317BABF03C90AA2B277B1AAE46D9C272ED5EAE56213E4A4A18F6A8751F023EA8E15FEE8DE348D7F526FD86200C4E516BF8C3B0ECED20CD5F4D3A710693FAE2AE34467C218BE1FA91C411FEDE6298EA0B558A72FF7124460058BFE9C8045BDDC2D47CD67F80C83717539F6BC04A669E7C84F4472FB71BF89E6EAB8DFCC105DA6ACDA081A0DE0D61235845358D1205E0D5EC3BA4D68ADC2DDE7B51A620AD31BE6B97D6639D1001868B2ABC5A3011D47938804774F28524E429353FFD94FA76296533F45E2DDADAF064C477686B630C829D1FFDD8E031B4718795CE3AAF418D734CCC0E31A177F0902780781FB34E2D60ED7E71C8613D3689CD40747918FF16B5AEFC5875A99E2E23FF94930B4FC8136FD7833EFA95ACCDA495C58B47692D4E8B776AA877D214C165A2FDB54EB71BABE82D9BCA938AF20CF1304F77B9C7C9BE3883B8E76BD4D20DED70DC4077B0F8F071FDEBD07DEC1FB1FE1C1BB4E41B94B04F624BEBBB7FF611B6359912FD87FF7DE8A54E138F89AA2DEE1FB3FD6DFF77531CCE199A7AC87B345ACB8740165DFAD1BD4E9BB76A129EBDEDCA24583BA8C8446C4D0A3A1D177BB72B53DAE9ED14CD7A64DB5B116A4B5FC2E1D8F551D6AE1D91C21D8499C6AC93A5E4193A4A0B6BF1CAFD7A8FF4AAB1423C8D06DA8DAA36D67DEC8CC7916025F967FD49D3A35A49CC4D1A39F84B06DE5C718052A1019EB7C03D214CD1CDE2F207DDABEB343374F9083A20566B8DEBAB42173E3982C6B5D73F77B7C0E5C14CACEA2A2566FBCCFB1FB2DCEB3B3C83B4561F16BE63680C59F777EA80F60459D63D785695A1CD942EF24CE37DBB46EA72245801A7BE97A12003FE4AF5DA9507ADF14DDAC5FF9259835ACA09869BEFE73BCF205DB4C5A425354AC6A5542A96A5DCC54D5024C4FD3BAA458D1B28052CFAA94B59D41D943F6B70625ECF4F706FD26EFED2FF6C6DA5894DD67E9F05443D2AF20C86D8BEA341ACA20607F3494B0D31F0DA59AE8E767DF2B56251A1BE6A63082D72ACFDF8BABC71CA5D9D0C38168E6D0C2878901A2E1729CA6B1EB97A380970A264EF9C966A0A59CA37DE45FB58D398347ED44C5FC620644BA1DCD76E7F33DC65E3A82DA3B651B41C4FD0452CCDF1819C88561520C5650EC6E523404FD2863FDDD8F5C7F0D02DD7653001D6E79151DD78AA59F9CC27579E732D3358F1D7D5AB1D42057D970B9C09CCDC407791735F45C447A6B43D32759673191C6714CFE3D0E8D8160C149252A9A3A87F0CE460F9F95F49755F5867361C97999C2A9740ECF18A722AF10183BB2C6F15BAF50DEC783D5BA8D136ED5FDF476C22E7BC6257418C98117E621C4B12BE9207BB45D96D7D1290C60069D63B77A9BE604A42EF0D815145ACB78068AF15C97393CDBCE0A4168252D9FE8E99F424BE808E79F950DE488828495A8CF55D9AB4DBF33471283F8A4226D26F0CB3A75B315C7945B6C00E7949B444701E1B9EF180E5AA729751D80CE594ECD41A964A9C041EB6CCA200E4A5A6C0407254DF2E61CB4CA4EEBF63F95AA9E9A7B9239F2E1A775A9B946F04DC21E1373CD2AED84EA64A8064C58F73C7D281EC217DE0BCA48CF3A359BD6592EDA450AF05B98B16FB0A00DC926E3C54B09317B21128ADADC3058D47313B47A6B0A95B06D72400F9DDCFC89A0C9520AE4FA508BC52216F62AF5A8512903DC8C5C05E8E6321283B579A4C0A8AFF131004C9433686073B62A6D61BDB433806DCE41A5B0F5844CC1620353E090E4BB5C5879E58B5F74FC30490AB7CD65061B13964C52C0182C190EE80987B48BB1CDB8AF8FA96CA74C65764C665AB0A52C7B2982C722992DEBCA2E980BADAB9B65EB9867639B2F0BA21D136BBA5DD8C5B49CBBCB1C5B2AB23FBAF91FAC2175B497D9479CAEC10DC2CE20BD8D22BA14C31A46271B61928FC01A567786C4408ADC81C0484D63AC5BA99987D456E26D894D36C5BDAC446D6005566A1A63DD4AB58FAA8DC4D996196CCC7A9988DC44591A6CCD3173BBDE6F9F2D1715B553FDC37221E0805A5E82F5DA8F56182754FD8B735B11429DFC706BCE941456180B97B036BD3B692565710256907A8A44234DCFFD24CD4E41061E4071C87EE2854C31EEEE46B0D66B447236306C5F366BBFA652F1FFAAA29CC189B329AC21CE513B0B2685B2C990BF76626B3B055117084022A75C3A89833C8CB88F68471563562F15E250D52FFA083837128E83FFAE8F46B31DE188F4337D543E87118ECD2FA12F81C34F84C3731EEB63D3A75738B0EA64AB88059433325909C6F399DC11399AB4C69A6A9D6834D8A4601AC34D517F3B86D741ADAE358B70ABA7DD9029661E9108AA583759ECE0679F766C4549A92354DE6737E4BAC8C42B04220144A16E72683A1D9128BA5C477B51843942CB51E5BA49C36E818804492E8A4C23346D36D936639420FB601AAA843043F48E818C9A944521A62ED54B524DBAA2905497EA256943AAA210B629D8535EC39BA294D7149CDA8822F2367686930C527F34C951149D4493A470BA474EC76228836042510823CAF6924AF19D28E452A57B4966B720C242BDE410B4250A7144D95E5249B6128558B2F077BE43106567CCC2047E54D6213E48AB0BCD4D9BD868C8B36B7ED13A7FAC68CEA4A82C75527BFCD8BDA3C410227337A7F1B8C14527F46294E6C21E91E1105CE21BADE3DAA3D99EFD25C2D1E82771559165311608DCB8425E090D2C7684110F8CF14A0A070E5CF9FB647A5F74A864D4F5F4E1BCB9072811B613556B8606225F58FD648881BDE4CF8061CFF451491E061C937C62E09624D902E199E423032D45F9908E39103E6D8200B8935D5912051C9D7DAA8FCCA153C0A1398F3B607374A69FE9A37218177060CE637DEC0DFD023D854E78DD223C45EEBC70A96E15F55BB90830B61311ED2C7CB097D97120EC6743ACFA757506ACFE7D92DE243C6DEFEC4DD565B27EDE24C010471EE2357032F048DF5D176312EF7613C15DF66EBB18CFCC67B7EA19CC613B5DA495DE1EBA5387EBCBFAA05BFD1526E6E4BB2A32731A33A289FD35CD60382F0ACC6F7F0B4E02BFCC1134052E41E43FC234ABF80C66FBBB7BFBD4879CA6F351A5459A7A01E7A200462B217E317EB46F1BF985B9958C2486F40438A76FF40C12F709247F09C1CB5F2D7CA2A81F1EFFB343FD30659F12EA872CFC3C503F583A77867902739BFE0259EAE568F6EFB2EAA173F1CF7BB2F68E739DA0817AE8EC3A7FE08AF4215F91BCF13CE24770B63252D87371DB1DCCFD968D3D787B43933D02C7EC6EF78B334245ED7C55C6A21DB85F8AB187CF7CFCA24B106841B61D0BF83C1E93F970C8D60304EF5B21D67D81F8FE877574FA9B1E5B10407EA7C34440AF6F6F7477CAAD7EF5629B4EA9F8D08595BE557EBCC2BA147B8B57D509ACBDC948F521096B13DE14978BC2C3CE21F81E1BCBB2EC6B3DBE62B0015519B86874F1BFF2E71DE7A2981C7ECBD1833B64D0C2C4349BACA500A8FE8E40ABE81F6F82A05FDFE4C8A7ABAAA42FF7EC7E92B6DF489BAA6A0F6DCCC9FC3BF4A84D46FDAD4C6A1C12FD5E619325CA57EF643AD3E4BFDDB84770D07351A9B8D59D72FEC137DF49F2E8E6FBB9058F52BE17A2ED0DAE8C1ABE8B0945B4F05DB08494F01EFA332B29E1CD1ACBA788EFA29A901EBE4B02832687D79F109A9A23AE0838E7814384A4ADCC0AD35A25301CDCBD063ACBB36D0067954BBBDF62F18D71545B9B3A6F580A6A6BD863FAFD60BCD3D648A6092E141179D0F6F9A487663395BF2DDC45F4DBE1896EE95B94444CDDE9CAFB104EF7F726F1DB5E1DF3EB46BED5CFB1DF3C93B3E500C5A5A051F17C7D7F014BEFF5ABA906AE6E4CCB532157DEE40AA5146E5BE7541E924659F26A886E227320E7EAC79E3C01BE4F0E559E9C486F0896CFA17D4D749BD720C13E7D26E489395BBDA795D32B7E8FCE26BAEC3B71673362359E98AF8D357F8EEC69DA53E8E81CC52CD917DDADF5CD6CCE8D6005F7707579FA68E63DC4C805AAE48994AC949645ED1F1869D4739E3C39C9A45460BB1D96CB6D8B29C58B7944057A74A13A966861C4894CAEBB59D9C4639ED0EBE3AF77BF341C819AC2364141287053442C54CCE9470BD6E257E609D2665F664230238829216F989935EBA5A3D49C7519B95801D7A64C76BD9290CAAECBC8650B182C2740F9DC9193981344193A4266C67D634CCE54F814932AC90CD5D1D86F8898B9971F49E6095D1EE7E9112D73695A796CF98A45270745C8BB3F656265A2250AD27E55824160133E53FF947994AD188598A004AF75DA37CAB66893AD98C4E6D031A04966DFD0441B9D3C2AEEC7547F9DC2D45F6D20960833822EB1C569CB5C448F71B3D3A2346A8A5067C7973003C54BC2C749E63F0237438F8BAB31E5378ACBEB06C505AD07E85D44D779B6CE33D464183E04C4517CB16393C92FB9A0499D97D7EB32C6DB680252D32FAE145D471F733FF05ABDCF39A7D50288622B585F4429FA322B2EA4AC5E5BA4AB38D204AACDD7EE60EF60B80E10587A1DDD8267D84537E47E9FE10AB8AF9BBB092210754790665F9EFA60958030AD3136F5D19FC887BDF0E5A7FF03090513F754A60000 , N'6.4.4')

