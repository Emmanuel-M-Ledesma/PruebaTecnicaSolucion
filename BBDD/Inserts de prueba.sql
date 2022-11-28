USE webapi
GO

--Creando proveedores para pruebas
insert into Proveedor values ('prueba1', 20)
insert into Proveedor values ('prueba2', 25)
insert into Proveedor values ('prueba3', 30)
insert into Proveedor values ('prueba4', 23)
insert into Proveedor values ('prueba5', 26)

--Creando usuarios y asignando a proveedores
insert into Usuario values ('Prueba1', 1234, 1)
insert into Usuario values ('Prueba2', 1234, 2)
insert into Usuario values ('Prueba3', 1234, 3)
insert into Usuario values ('Prueba4', 1234, 4)
insert into Usuario values ('Prueba5', 1234, 5)

insert into Provincia values('Buenos Aires')
insert into Provincia values('Cordoba')
insert into Provincia values('Chaco')
insert into Provincia values('Entre Rios')
insert into Provincia values('Corrientes')
insert into Provincia values('Salta')
insert into Provincia values('Tucuman')

--Creando sucursales y 
Insert into Sucursal values ('Sarmiento', 3213, 'Cordoba', 2)
Insert into Sucursal values ('Sarmiento', 456, 'CABA', 1)
Insert into Sucursal values ('Calle 2', 354, 'Cordoba', 2)
Insert into Sucursal values ('Mitre', 3213, 'Corrientes', 5)

--asignando sucursales a proveedores
insert into ProvSuc values (1,1)
insert into ProvSuc values (2,2)
insert into ProvSuc values (3,3)
insert into ProvSuc values (4,4)
insert into ProvSuc values (5,1)

--Creando estados de pedidos
Insert into EstadoPedido values (1,'Pendiente')
Insert into EstadoPedido values (2,'Finalizado')

--agregando pedidos al proveedor 1
Insert into Pedido values (1,null, 1, '11/27/2022', 'Prueba de pedido pendiente 1', 500)
Insert into Pedido values (1,null, 1, '11/27/2022', 'Prueba de pedido pendiente 2', 500)
Insert into Pedido values (1,null, 1, '11/27/2022', 'Prueba de pedido pendiente 3', 500)
Insert into Pedido values (1,null, 2, '11/27/2022', 'Prueba de pedido finazado 1', 500)
Insert into Pedido values (1,null, 2, '11/27/2022', 'Prueba de pedido finazado 2', 213)
Insert into Pedido values (1,null, 2, '11/27/2022', 'Prueba de pedido finazado 3', 765)
Insert into Pedido values (1,null, 2, '11/27/2022', 'Prueba de pedido finazado 4', 2133)

--agregando pedidos al proveedor 2
Insert into Pedido values (2,null, 1, '11/27/2022', 'Prueba de pedido pendiente 1', 500)
Insert into Pedido values (2,null, 1, '11/27/2022', 'Prueba de pedido pendiente 2', 500)
Insert into Pedido values (2,null, 1, '11/27/2022', 'Prueba de pedido pendiente 3', 500)
Insert into Pedido values (2,null, 2, '11/27/2022', 'Prueba de pedido finazado 1', 500)
Insert into Pedido values (2,null, 2, '11/27/2022', 'Prueba de pedido finazado 2', 544)
Insert into Pedido values (2,null, 2, '11/27/2022', 'Prueba de pedido finazado 3', 3213)
Insert into Pedido values (2,null, 2, '11/27/2022', 'Prueba de pedido finazado 4', 124)

--agregando pedidos al proveedor 3
Insert into Pedido values (3,null, 1, '11/27/2022', 'Prueba de pedido pendiente 1', 500)
Insert into Pedido values (3,null, 1, '11/27/2022', 'Prueba de pedido pendiente 2', 500)
Insert into Pedido values (3,null, 1, '11/27/2022', 'Prueba de pedido pendiente 3', 500)
Insert into Pedido values (3,null, 2, '11/27/2022', 'Prueba de pedido finazado 1', 321)
Insert into Pedido values (3,null, 2, '11/27/2022', 'Prueba de pedido finazado 2', 567)
Insert into Pedido values (3,null, 2, '11/27/2022', 'Prueba de pedido finazado 3', 7876)
Insert into Pedido values (3,null, 2, '11/27/2022', 'Prueba de pedido finazado 4', 543)


select * from Proveedor
select * from Usuario
select * from ProvSuc
select * from Sucursal
select * from EstadoPedido
select * from Provincia
select * from Pedido