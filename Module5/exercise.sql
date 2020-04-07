create schema Sales Authorization dbo;

create table Sales.MediaOutlets
(
MediaOutletId int not null,MediaOutletName varchar(20),ContactNumber varchar(20),City varchar(20)
);

create table Sales.PrintMediaPlacement
(
PrintMediaPlacementId int not null,
MediaOutletId int not null,
PlacementDate datetime not null,
Cost decimal(10,2) not null
);

alter table Sales.MediaOutlets 
add constraint IX_MEDIAOUTLET 
UNIQUE CLUSTERED(MediaOutletId);

alter table Sales.PrintMediaPlacement 
add Constraint IX_printMediaPlacement 
unique Clustered(PrintMediaPlacementId)

