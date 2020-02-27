## Documentación

* [Conversión de HTML a PDF](#Creación-de-un-PDF-descargable-desde-un-archivo-HTML)
* [Envío de mensajes SMS con Twilio](#Envío-de-mensajes-SMS-con-Twilio)
* [Envío de correos con Sendgrid](#installation)

## Creación de un PDF descargable desde un archivo HTML

Esta sección del documento explica cómo crear un archivo en formato de documento portátil (PDF) desde la estructura de un archivo hyper text markup language(HTML).
Un archivo PDF es una forma de presentar e intercambiar documentos. Dichos pueden contener vínculos, botones, formularios, audio, vídeo, entre otros. 
Por otro lado un archivo HTML es un lenguaje de marcado que se utiliza para el desarrollo de páginas o sitios web. Indica la manera en que está ordenado o estructurado el contenido de la página, para ello se utilizan etiquetas para enmarcar texto.
El código fuente de la carpeta CreacionPDF_HTML del repositorio contiene los elementos necesarios para la creación y conversión de un HTML a un PDF.

Breve explicación del código fuente:
Primeramente se debe descargar los 3 scripts que contiene este repositorio de la carpeta js. Después se debe crear una carpeta en visual studio code con el nombre que se desee. Dentro de la carpeta crearemos otra carpeta con el nombre de js, en la misma pegaremos los 3 scripts. Creamos un archivo ejemplo.html (el nombre que desee con extensión html). Creamos una estructura básica de HTML como la que aparece en el archivo pdfDesdeHtml.html del repositorio. Por ejemplo:
```html
<!Doctype html>
<html>
    <head>
	<title>Nombre de página</title>
    </head>
    <body>
        
    </body>
</html>
```
 
Seguidamente creamos dentro del body un elemento div con el siguiente id=”HTMLtoPDF”.
```html
<!Doctype html>
<html>
    <head>
	<title>Nombre de página</title>
    </head>
    <body>
        <div id="HTMLtoPDF">
        </div>
    </body>
</html>
```

Dentro del div podemos agregar todos los elementos que estarán en el contenido del archivo PDF. Por ejemplo:
```html
<div id="HTMLtoPDF">
    <h2>Los nutrientes</h2>
    <p>Los alimentos son unas sustancias (sólidas o líquidas) que ingerimos y que nuestro organismo transforma obteniendo unas sustancias químicas, nutrientes, necesarios para la formación, crecimiento y reconstrucción de nuestros tejidos. Alimentos son la leche y sus derivados, las legumbres, las carnes, el pescado, la fruta, las verduras, las hortalizas, los cereales, la mantequilla, etc. y nutrientes, los hidratos de carbono, las proteínas, la fibra, los minerales y los lípidos.
    </p>  
</div>
```

Fuera del div pero dentro del body creamos un elemento <a> que representará el hipervínculo que al darle click llamará la función que hace la conversión de los documentos. Por ejemplo:
```html
 <a href="#" onclick="HTMLtoPDF()">Download PDF</a>
```
La función “HTMLtoPDF()” se encuentra en uno de los scripts que copiamos a nuestra carpeta js y es la que realiza la conversión.
Seguidamente incluimos los scripts necesarios para la conversión. Se colocan dentro del body después del elemento a, de la siguiente manera:
```html
        <script src="js/jspdf.js"></script>
        <script src="js/jquery-2.1.3.js"></script>
        <script src="js/pdfFromHTML.js"></script>
```
	
El script js/pdfFromHTML.js tiene la función mencionada anteriormente. La variable source hace uso del id que le pusimos al div. Traduciéndose en que todo lo que está dentro del div sea utilizado para crear el contenido del PDF.
```cs
function HTMLtoPDF(){
    var pdf = new jsPDF('p', 'pt', 'letter');
    source = $('#HTMLtoPDF')[0];
    ...
}
```

Explicación y demostración gráfica del proceso necesario para implementar la funcionalidad:
<div align="center">
    <iframe width="560" height="315" src="https://www.youtube.com/watch?v=RzVcKMVioSg"
frameborder="0" allow="encrypted-media" allowfullscreen></iframe>
</div>

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

## Envío de mensajes SMS con Twilio

Enlaces necesarios para la realización del ejercicio:
1- https://www.twilio.com/
2- https://docs.microsoft.com/en-us/azure/twilio-dotnet-how-to-use-for-voice-sms

Esta sección del documento explica cómo enviar un `Short Message Service (SMS)` usando Microsoft Visual Studio y 
el `Aplication Program Interface (API)` de Twilio.

### ¿Qué es Twilio?

Es una aplicación que permite a los desarrolladores , añadir voz y mensajes en aplicaciones.
Virtualizan toda la infraestructura necesaria en una nube, la cual puede ser usada atravez del Twilio communications API platform.
Las aplicaciones son simples de construir y a su vez, escalables.
Funciona con el sistema pay-as-you-go, el cuál va a realizar un cobro cada vez que se realice una accion.


### Pasos:
1 - Registrarse en Twilio(https://www.twilio.com/),
2 - Crear un `Console App(.net)` en visual studio.

3 - Colocar el siguiente código en el main, para probar su funcionalidad: 
```cs
            // Use your account SID and authentication token instead
            // of the placeholders shown here.
            const string accountSID = "El SID va dentro de las comillas";
            const string authToken = "El authToken va dentro de las comillas";

            // Initialize the TwilioClient.
            TwilioClient.Init(accountSID, authToken);

            try
            {
                // Send an SMS message.
                var message = MessageResource.Create(
                    to: new PhoneNumber("Aqui va el numero que se registro en Twilio"),
                    from: new PhoneNumber("+14155992671"),
                    body: "Hola mundo esto es una prueba!");
            }
            catch (TwilioException ex)
            {
                // An exception occurred making the REST call
                Console.WriteLine(ex.Message);
            }
```

4 -  Descargar desde el `Manage Nugets` el paquete de Twilio e instalarlo. 
5 -  Se referencia el Api de Twilio desde el Main.
6 -  Se ejecuta el programa.

Para más información visite el siguiente link que lo redireccionará al video de youtube que contiene la explicación 
y demostración gráfica del proceso necesario para implementar la funcionalidad:

Para mas información acerca de otras funcionalidades del API de Twilio visitar:
https://docs.microsoft.com/en-us/azure/twilio-dotnet-how-to-use-for-voice-sms,
https://www.twilio.com/blog/what-does-twilio-do
