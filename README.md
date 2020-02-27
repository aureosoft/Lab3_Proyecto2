## Documentación

* [Conversión de HTML a PDF](#Creación-de-un-PDF-descargable-desde-un-archivo-HTML)
* [Envío de mensajes SMS con Twilio](#Envío-de-mensajes-SMS-con-Twilio)
* [Envío de correos electrónicos con Sendgrid](#Envío-de-correos-electrónicos-con-Sendgrid)

## Creación de un PDF descargable desde un archivo HTML

Esta sección del documento explica cómo crear un archivo en `Formato de Documento Portátil (PDF)` desde la estructura de un archivo `Hyper Text Markup Language (HTML)`.

Un archivo PDF es una forma de presentar e intercambiar documentos, los cuales, pueden contener vínculos, botones, formularios, audios, vídeos, entre otros. 
Por otro lado, un archivo HTML es un lenguaje de marcado que se utiliza para el desarrollo de páginas o sitios web. Indica la manera en que está ordenado o estructurado el contenido de la página, para ello se utilizan etiquetas para enmarcar texto.
El código fuente de la carpeta `CreacionPDF_HTML` del repositorio, contiene los elementos necesarios para la creación y conversión de un HTML a un PDF.

***Breve explicación del código fuente:***

Primeramente, se debe descargar los 3 scripts que contiene este repositorio en la carpeta `js`. 
Después se debe crear una carpeta en [Visual Studio Code](https://code.visualstudio.com/#alt-downloads "Visual Studio Code") con el nombre que se desee. 
Dentro de la carpeta crearemos otra carpeta con el nombre de `js`, en la misma pegaremos los 3 scripts. Creamos un archivo `ejemplo.html` (el nombre que desee con extensión html). Creamos una estructura básica de HTML como la que aparece en el archivo `pdfDesdeHtml.html` del repositorio. Por ejemplo:
```html
<!Doctype html>
<html>
    <head>
	<meta charset="utf-8">
	<title>Título de la página</title>
    </head>
    <body>
        
    </body>
</html>
```
 
Seguidamente creamos dentro del `body` un elemento `div` como el siguiente: `id="HTMLtoPDF"`.
```html
<!Doctype html>
<html>
    <head>
	<meta charset="utf-8">
	<title>Título de la página</title>
    </head>
    <body>
        <div id="HTMLtoPDF">
        </div>
    </body>
</html>
```

Dentro del `div` podemos agregar todos los elementos que estarán en el contenido del archivo PDF.
Por ejemplo:
```html
<div id="HTMLtoPDF">
    <h2>Los nutrientes</h2>
    <p>Los alimentos son unas sustancias (sólidas o líquidas) que ingerimos y que nuestro organismo transforma obteniendo unas sustancias químicas, nutrientes, necesarios para la formación, crecimiento y reconstrucción de nuestros tejidos. Alimentos son la leche y sus derivados, las legumbres, las carnes, el pescado, la fruta, las verduras, las hortalizas, los cereales, la mantequilla, etc. y nutrientes, los hidratos de carbono, las proteínas, la fibra, los minerales y los lípidos.
    </p>  
</div>
```

Fuera del `div` pero dentro del `body` creamos un elemento `<a>` que representará el hipervínculo, que al darle `click`, llamará la función que hace la conversión de los documentos. 
Por ejemplo:
```html
 <a href="javascript:void(0)" onclick="HTMLtoPDF()">Download PDF</a>
```
La función `HTMLtoPDF()` se encuentra en uno de los scripts que copiamos a nuestra carpeta `js`, y es la que realiza la conversión.
Seguidamente incluimos los scripts necesarios para la conversión. Se colocan dentro del `body` después del elemento `a`, de la siguiente manera:
```html
        <script src="./js/jspdf.js"></script>
        <script src="./js/jquery-2.1.3.js"></script>
        <script src="./js/pdfFromHTML.js"></script>
```
	
El script `js/pdfFromHTML.js` tiene la función mencionada anteriormente. La variable `source` hace uso del `id` que le pusimos al `div`. Traduciéndose en que todo lo que está dentro del `div` sea utilizado para crear el contenido del PDF.
```js
let HTMLtoPDF = () => {
    const pdf = new jsPDF('p', 'pt', 'letter');
    source = $('#HTMLtoPDF')[0];
    ...
};
```

Explicación y demostración gráfica del proceso necesario para implementar la funcionalidad:
[![Cómo generar un archivo PDF desde HTML](https://img.youtube.com/vi/RzVcKMVioSg/hqdefault.jpg)](https://www.youtube.com/embed/RzVcKMVioSg "Cómo generar un archivo PDF desde HTML")


## Envío de mensajes SMS con Twilio

Enlaces necesarios para la realización del ejercicio:

[1- Twilio - web oficial](https://www.twilio.com/ "Twilio - web oficial")

[2- SMS en Twilio](https://docs.microsoft.com/en-us/azure/twilio-dotnet-how-to-use-for-voice-sms "SMS en Twilio")


Esta sección del documento explica cómo enviar un `Short Message Service (SMS)` usando `Microsoft Visual Studio` y 
el `Aplication Program Interface (API)` de Twilio.

### ¿Qué es Twilio?

Es una aplicación que permite a los desarrolladores , añadir voz y mensajes en aplicaciones.
Virtualizan toda la infraestructura necesaria en una nube, la cuál, puede ser usada a través del [Twilio communications API platform](https://www.twilio.com/platform "Twilio communications API platform").
Las aplicaciones son simples de construir, y a su vez escalables.
Funciona con el sistema [Pay as you go (PAYG)](https://en.wikipedia.org/wiki/Pay_as_you_go "Pay as you go (PAYG)"), el cuál, va a realizar un ***cobro*** cada vez que se realice una **acción**.


### Pasos:
[1 - Registrarse en [Twilio](https://www.twilio.com/ "Twilio") ]
[2 - Crear un `Console App(.net)` en `Visual Studio`.]
[3 - Colocar el siguiente código en el método `main`, para probar su funcionalidad:] 
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
[4 -  Descargar desde el `Manage Nugets` el paquete de `Twilio` e instalarlo.]
[5 -  Se referencia el Api de Twilio desde el Main.]
[6 -  Se ejecuta el programa.]

Explicación y demostración gráfica del proceso necesario para implementar la funcionalidad:
[![Envío de Sms con Twilio](https://img.youtube.com/vi/wU4GA0GQu2s/hqdefault.jpg)](https://www.youtube.com/embed/wU4GA0GQu2s "Envío de Sms con Twilio")



Para mas información acerca de otras funcionalidades del API de Twilio visitar:

[Cómo usar Twilio para voz y SMS](https://docs.microsoft.com/en-us/azure/twilio-dotnet-how-to-use-for-voice-sms "https://docs.microsoft.com/en-us/azure/twilio-dotnet-how-to-use-for-voice-sms"),

[¿Qué hace Twilio?](https://www.twilio.com/blog/what-does-twilio-do "https://www.twilio.com/blog/what-does-twilio-do")



## Envío de correos electrónicos con Sendgrid





