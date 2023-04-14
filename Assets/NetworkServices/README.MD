
## Owner
Grupo Ingenio Colombiano

## [1.0.0] - 2023-03-15

## Developers 
[ Diego Salamanca / diegocolmayor@gmail.com ] 

## Ftp account 

Acces to virtualPlant api services folder:
ip: 54.144.50.139  172.31.18.188
user: developerIngco
pass: Q6KbhEB6axq57RPt

### Endpoints

-[CheckFile] Save data into each prectices folder as json txt file
url :     http://54.144.50.139/virtualplantApiServices/userData/endpoint/CheckFile.php
# Type:
POST
# Body Form: 
    "FILENAME" 
    "PRACTICENAME" 
# Response HTTP: 
    200 - El archivo ya existe en el servidor
    201 - No existe, no se encuentra el archivo
    202 - No existe la carpeta de la práctica
    

-[UploadData] Save data into each prectices folder as json txt file
url : http://54.144.50.139/virtualplantApiServices/userData/endpoint/Upload.php

# Type: 
POST
# Body Form: 
    "FILENAME" recibe el nombre que tendra el archivo en el servidor
    "PRACTICENAME"  recibe el nombre de la práctica
    "FILEDATA"  recibe un string en formato JSON con los datos a guardar
# Response HTTP: 
    200 - El archivo y el directorio se crearon correctamente
    201 - No se pudo crear el directorio
    202 - No se pudo crear el archivo 



-[DownloadData] Save data into each prectices folder as json txt file
url : http://54.144.50.139/virtualplantApiServices/userData/endpoint/Download.php

# Type:
POST
# Body Form: 
    "FILENAME" 
    "PRACTICENAME" 
# Response HTTP: 
    200 - Responde con un texto en formato JSON con los datos encontrados en el archivo
    201 - No encuentra el directorio de la práctica
    202 - No encuentra el archivo 
   

-[ExcelReport] Save report on server and return a URL
url : http://54.144.50.139/virtualplantApiServices/reportData/endpoint/report.php

# Type: 
POST
# Body Form: 
    "studentName" 
    "tamplateName" 
    "reportName"
    "data"
# Response HTTP: 
    200 - El reporte se creo correctamente
    

-[SendMail] Send email using PHPExcel and SMTP  
url : http://54.144.50.139/virtualplantApiServices/mailService/endPoint/sendMail.php

# Type: 
POST
# Body Form: 
    "email1" 
    "email2" 
    "reportUrl"
    "studentName"
    "practiceName"
    "institution"
    "academicProgram"
    "subject"
    "studentCode"
    "teacherName"
# Response HTTP: 
    200 - El email se envio correctamente

-[SendValuation] Send email with user valuation
url : http://54.144.50.139/virtualplantApiServices/mailService/endPoint/sendValuation.php

# Type: 
POST
# Body Form:     
    "studentName"
    "practiceName"
    "value"
    "valueDetails"
# Response HTTP: 
    200 - El email se envio correctamente
   














