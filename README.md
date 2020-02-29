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

* [Descargar jQuery](https://unpkg.com/jquery@latest/dist/jquery.min.js)
* [Descargar jspdf](https://unpkg.com/jspdf@latest/dist/jspdf.min.js)

Después se debe crear una carpeta en [Visual Studio Code](https://code.visualstudio.com/#alt-downloads "Visual Studio Code") con el nombre que se desee. 
Dentro de la carpeta crearemos otra carpeta con el nombre de `js`, en la misma pegaremos los 3 scripts.

Creamos un archivo `ejemplo.html` (el nombre que desee con extensión html). Creamos una estructura básica de HTML como la que aparece en el archivo `pdfDesdeHtml.html` del repositorio.
Por ejemplo:
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
 <a href="javascript:void(0)" onclick="HTMLtoPDF()">Descargar PDF</a>
```
La función `HTMLtoPDF()` se encuentra en uno de los scripts que copiamos a nuestra carpeta `js`, y es la que realiza la conversión.
Seguidamente incluimos los scripts necesarios para la conversión. Se colocan dentro del `body` después del elemento `a`, de la siguiente manera:
```html
        <script src="./js/jquery-2.1.3.js"></script>
        <script src="./js/jspdf.js"></script>
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

Resumen de los pasos necesarios para enviar correos electrónicos utilizando Sendgrid:

1. Crear cuenta en [Sendgrid](https://signup.sendgrid.com "signup")

2. Iniciar sesión en [Sendgrid](https://app.sendgrid.com/login "login")

3. Crear API key y copiar el key generado.
    * Escribir un `nombre` para el Api Key.
	* Seleccionar que sea de tipo: `Restricted Access`
	* En el submenú Mail Send activar la casilla: `Mail Send`.
	* Presionar el botón: `Create & View`.

4. Crear en `Visual Studio` un proyecto de tipo `Console App`.

5. Agregar el siguiente `Nuget`: `Sendgrid`.

6. 
|   |   |
| :---: | :---: |
| Seguir los pasos del siguiente video para continuar:  | [![Código c# para envíar correo con Sendgrid](https://img.youtube.com/vi/uttXidmt9mI/hqdefault.jpg)](https://youtu.be/uttXidmt9mI?t=71 "Código c# para envíar correo con Sendgrid")  |




![](data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAUAAAAFACAYAAADNkKWqAAAgAElEQVR4nO3dd3gTV7438Pz3XqqNiSm52bC72bv33d27723Z0GyaMTUQIAVCD8022JZNC4RAgNBCANMJzfQWwpKEHkog9F5MN6bbVh25qLmMvu8fI8lyL4yIzPnyPL9HGmzQR+fM+U7R0cxrUPmP2WyGJEmqlNlsVptHH3300efxvQYATqdTtZIkCSaTSZWSJElVG3300Ueft48BSB999AnrYwDSRx99wvoYgPTRR5+wPgYgffTRJ6yPAUgfffQJ62MA0kcffcL6GID00UefsD4GIH300SesjwFIH330CetjANJHH33C+hiA9NFHn7A+BiB99NEnrI8BSB999AnrYwDSRx99wvr8OgDNZjNkWaaPPvroU93n9wFYHbYg9NFHX/X1MQDpo48+YX2qBqAsy6pfslrNxqOPPvro8/a9pvZ/qPYxP3300UefL3wA8JokibXLSx999NHndDIA6aOPPoF9fh+A7mN++uijjz7hAtDp9O8tCH300Vd9fQxA+uijT1gfA5A++ugT1scApI8++oT1MQDpo48+YX0MQProo09YHwOQPvroE9bHAKSPPvqE9TEA6aOPPmF9DED66KNPWB8DkD766BPWxwCkjz76hPUxAOmjjz5hfaoFoNFo9OsGpI8++ugrWtwDpI8++oT1AVD/kvhqNyB99NFHny98ANS/K5w/v2H66KOPPm8fb4tJH330CevzWQC6T1z6awPSRx999HEPkD766BPWxwCkjz76hPUxAOmjjz5hfQxA+uijT1gfA5A++ugT1scApI8++oT1MQDpo48+YX0MQProo09YHwOQPvroE9bHAKSPPvqE9TEA6aOPPmF9DED66KNPWB8DkD766BPW59cBaDabIcsyffTRR5/qPr8PwOqwBaGPPvqqr48BSB999AnrUzUAZVn260tq00cfffR5+1S/KZLax/z00Ucffb7w8baY9NFHn7A+BiB99NEnrM/vA9B9zE8fffTRJ1wAOp3+vQWhjz76qq+PAUgfffQJ62MA0kcffcL6GID00UefsD4GIH300SesjwFIH330CetjANJHH33C+hiA9NFHn7A+BiB99NEnrI8BSB999AnrYwDSRx99wvoYgPTRR5+wPgYgffTRJ6xPtQA0Go1+3YD00UcffUWLe4D00UefsD4A6l8SX+0GpI8++ujzhQ+A+neF8+c3TB999NHn7eNtMemjjz5hfT4LQPeJS39tQProo48+7gHSRx99wvoYgPTRR5+wPgYgffTRJ6yPAUgfffQJ62MA0kcffcL6GID00UefsD4GIH300SesjwFIH330CetjANJHH33C+hiA9NFHn7A+BiB99NEnrI8BSB999AnrYwDSRx99wvr8OgDNZjNkWaaPPvroU93n9wFYHbYg9NFHX/X1MQDpo48+YX2qBqAsy359SW366KOPPm+f6jdFUvuYnz766KPPFz7eFpM++ugT1scApI8++oT1+X0Auo/56aOPPvqEC0Cn07+3IPTRR1/19TEA6aOPPmF9DED66KNPWB8DkD766BPWxwCkjz76hPUxAOmjjz5hfQxA+uijT1gfA5A++ugT1scApI8++oT1MQDpo48+YX0MQProo09YHwOQPvroE9bHAKSPPvqE9akWgEaj0a8bkD766KOvaHEPkD766BPWB0D9S+Kr3YD00Ucffb7wAVD/rnD+/Ibpo48++rx9vC0mffTRJ6zPZwHoPnHprw1IH3300cc9QProo09YHwOQPvroE9bHAKSPPvqE9TEA6aOPPmF9DED66KNPWB8DkD766BPWxwCkjz76hPUxAOmjjz5hfQxA+uijT1gfA5A++ugT1scApI8++oT1MQDpo48+YX0MQProo09Yn18HoNlshizL9NFHH32q+/w+AKvDFoQ++uirvj4GIH300SesT9UAlGXZry+pTR999NHn7VP9pkhqH/PTRx999PnCx9ti0kcffcL6GID00UefsD6/D0D3MT999NFH328agEZJqZcJdDr9ewui+DJgMqnTyS/ik6HUi7afZFSqpGXFB1eJ0r+vqs9cbL31L19V26/s9ROyVzn9fA+weqyADMBXu39fVR8D0BWA/jGASxvQr+4K6GtfPpzO/BfwGVwlavvRVz18+a4qz1I8GF2HwBULQO+9gpfRgAzAFy0GIH0i+F44AMsGFpz7KxgQpZ0L/G0CsPiu/KvVwfTRR58vfFUKwLI+DGEA+lcH00cffaWXT6bBFD0ZX7BctZPnvm5A9wnRV6eDC7ez7zYgFT30KNvpf+1XuExmqdzZD95VdAfBe/nVDJiyx/Vv7yu9GIBOBiADsOxiAFZuffM/X+lVYgAWnQZRUMohcOk/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fS/JxwCkz5987gAsdyJ06VdUFbsByz4ELm+5sr7qfxMjXwVg4Q12cV/lD41+i/arysRe/+rfyvrKni9ZcV/J/VuR8VLmOUAGIANQ3fZjAJbVfgzAqvp8FID+0ICVvUkQffTRR19Fy+8DsHpv4eijjz5/9zEA6aOPPmF9qgagLMswm82QJFPlAzYAAAU2SURBVEmVMpvNqjYeffTRR5+37zW1/0O1j/npo48++nzh89wVTqRdXvroo48+p5MBSB999Ans8/sAdB/z00cfffQJF4BOp39vQeijj77q62MA0kcffcL6GID00UefsD4GIH300SesjwFIH330CetjANJHH33C+hiA9NFHn7A+BiB99NEnrI8BSB999AnrYwDSRx99wvoYgPTRR5+wPgYgffTRJ6yPAUgfffQJ61MtAI1Go183IH300Udf0eIeIH300SesD4D6l8RXuwHpo48++nzhA6D+XeH8+Q3TRx999Hn7eFtM+uijT1ifzwLQfeLSXxuQPvroo497gPTRR5+wPgYgffTRJ6yPAUgfffQJ62MA0kcffcL6GID00UefsD4GIH300SesjwFIH330CetjANJHH33C+hiA9NFHn7A+BiB99NEnrI8BSB999AnrYwDSRx99wvoYgPTRR5+wPr8OQLPZDFmW6aOPPvpU9/l9AFaHLQh99NFXfX0MQProo09Yn6oBKMuyX19Smz766KPP26f6TZHUPuanjz766POFj7fFpI8++oT1MQDpo48+YX1+H4DuY3766KOPPuEC0On07y0IffTRV319DED66KNPWB8DkD766BPWxwCkjz76hPUxAOmjjz5hfQxA+uijT1gfA5A++ugT1scApI8++oT1MQDpo48+YX0MQProo09YHwOQPvroE9bHAKSPPvqE9TEA6aOPPmF9qgWg0Wj06wakjz766Cta3AOkjz76hPUBUP+S+Go3IH300UefL3wA1L8rnD+/Yfroo48+bx9vi0kfffQJ6/NZALpPXPprA9JHH330cQ+QPvroE9bHAKSPPvqE9TEA6aOPPmF9DED66KNPWB8DkD766BPWxwCkjz76hPUxAOmjjz5hfQxA+uijT1gfA5A++ugT1scApI8++oT1MQDpo48+YX0MQProo09YHwOQPvroE9bn1wFoNpshyzJ99NFHn+o+vw/A6rAFoY8++qqvjwFIH330CetTNQBlWfbrS2rTRx999Hn7VL8pktrH/PTRRx99vvDxtpj00UefsD4GIH300Sesz+8D0H3MTx999NEnXAA6nf69BaGPPvqqr48BSB999AnrYwDSRx99wvoYgPTRR5+wPgYgffTRJ6yPAUgfffQJ62MA0kcffcL6GID00UefsD4GIH300SesjwFIH330CetjANJHH33C+hiA9NFHn7A+BiB99NEnrE+1ADQajX7dgPTRRx99RYt7gPTRR5+wPgDqXxJf7Qakjz766POFD4D6d4Xz5zdMH3300eft420x6aOPPmF9PgtA94lLf21A+uijjz7uAdJHH33C+hiA9NFHn7A+BiB99NEnrI8BSB999AnrYwDSRx99wvoYgPTRR5+wPgYgffTRJ6yPAUgfffQJ62MA0kcffcL6GID00UefsD4GIH300SesjwFIH330CetjANJHH33C+vw6AM1mM2RZpo8++uhT3ef3AVgdtiD00Udf9fUxAOmjjz5hfaoGoCzLfn1Jbfroo48+b5/qN0VS+5ifPvroo88XPt4Wkz766BPWxwCkjz76hPX5fQC6j/npo48++oQLQKfTv7cg9NFHX/X1MQDpo48+YX0MQProo09YHwOQPvroE9bHAKSPPvqE9TEA6aOPPmF9DED66KNPWB8DkD766BPWxwCkjz76hPUxAOmjjz5hfQxA+uijT1gfA5A++ugT1scApI8++oT1MQDpo48+YX0MQProo09YHwD1L4mv9h/66KOPPl/5/j97Els4QoEh0wAAAABJRU5ErkJggg==)




Explicación completa, paso a paso:

[![Envío de correos electrónicos con Sendgrid](https://img.youtube.com/vi/uttXidmt9mI/hqdefault.jpg)](https://www.youtube.com/embed/uttXidmt9mI "Envío de correos electrónicos con Sendgrid")





