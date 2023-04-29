set NOCOUNT on;
/*
use Master;
go
drop database IncidentDashboard
*/
create database IncidentDashboard;
go

print 'IncidentDashboard database created...';

use IncidentDashboard;
go

create table Department
(
    DepartmentId int identity(1, 1) primary key,
    DepartmentName varchar(50) not null
);
go

print 'Department table created...';

insert into Department values('OFFICE');
go

create table Site
(
    SiteId int identity(1, 1) primary key,
    Address1 varchar(100) not null,
    Address2 varchar(100) null,
    City varchar(100) not null
);
go

print 'Site table created...';

insert into Site values('10 Downing Street', null, 'London');
go

create table Role
(
    RoleId varchar(10) primary key,
    RoleDescription varchar(100) not null
);
go

print 'Role table created...';

insert into Role values('ADMIN', 'Add and manage users and incidents');
insert into Role values('MANAGER', 'Add and manage incidents. Includes closure');
insert into Role values('REPORTER', 'Add and manage incidents');
insert into Role values('VIEWER', 'View incidents');
go

create table IncidentGroup
(
    IncidentGroupId varchar(10) primary key,
    IncidentGroupDescription varchar(100) not null
);
go

print 'IncidentGroup table created...';

insert into IncidentGroup values('DANGDRIVE', 'Dangerous driving within the grounds');
go

create table Users
(
    UserId int identity(1, 1) primary key,
    FirstName varchar(30) not null,
    LastName varchar(30) null,
    [Password] varchar(max),
    Salt varchar(max),
    IsActive bit default 1,
    RoleId varchar(10) not null foreign key references Role(RoleId)
);
go

print 'Users table created...';

insert into Users values('ADMIN', null, 'd85f42ff4d6f164b7fdd6953af624b3d83222f7adfb5deb5a2112940ff2522c5', 'qiWa7g6#Z@=Xx', 1, 'ADMIN');
go

create table Incident
(
    IncidentId int identity(1, 1) primary key,
    IncidentGroupId varchar(10) not null foreign key references IncidentGroup(IncidentGroupId),
    SiteId int not null foreign key references Site(SiteId),
    DepartmentId int not null foreign key references Department(DepartmentId),
    ReporterId int not null foreign key references Users(UserId),
    SeverityLevel numeric(2, 1) not null check(SeverityLevel between 0 and 10),
    IncidentDatetime datetime2 not null,
    IncidentCreationDatetime datetime2 not null default current_timestamp,
    IncidentResolutionDatetime datetime2 null
);
go

print 'Incident table created...';

insert into Incident values('DANGDRIVE', 1, 1, 1, 6, current_timestamp, current_timestamp, null);
go

create table Incidentees
(
    IncidentId int not null foreign key references Incident(IncidentId),
    InvolvedPartyUserId int not null foreign key references Users(UserId)
);
go

print 'Incident table created...';

insert into Incidentees values(1, 1);
go

create table IncidentPhotos
(
    PhotoId int identity(1, 1) primary key,
    IncidentId int not null foreign key references Incident(IncidentId),
    IsMain bit,
    PhotoUrl varchar(500)
);
go

print 'IncidentPhotos table created...';
go

create or alter trigger OneMainPhotoPerIncident
on IncidentPhotos
after insert, update
as
declare
    @l_Counter int;
begin
    select @l_Counter = count(*)
    from IncidentPhotos ip
    join inserted i on i.IncidentId = ip.IncidentId and i.IsMain = 1 and i.PhotoId != ip.PhotoId;

    if @l_Counter > 0
    begin
        RAISERROR('Can only be 1 main photo per incident', 16, 1);
    end
end;
go

print 'Set up scripts complete...'