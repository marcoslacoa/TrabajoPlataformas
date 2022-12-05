# TrabajoPlataformas

El programa funciona mediante Windows Forms. Está creado en C# utilizando EF Core para persistir la información.
El mismo empieza con un formulario de inicio o registro de sesión, donde el programa checkea al usuario y lo logea. Una vez logeado, este podrá visualizar la informacion que corresponde a sus cajas de ahorro, plazos fijos, tarjetas, pagos y movimientos realizados con estos. También tendrá las demas funcionalidades de CRUD como modificar, eliminar, crear. El sistema permite depositar, retirar y transferir dinero entre diferentes usuarios, con diferentes cajas cada uno. La relación que existe aquí es de muchos a muchos, la única del sistema. Muchas cajas, muchos usuarios. Existe una entidad que relaciona a ambos y permite el funcionamiento del programa.

El trabajo fue realizado por Amillano, Loire y Lacoa.
