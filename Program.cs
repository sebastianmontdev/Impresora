using System;
using System.IO;
using System.Text;

// Punto de entrada principal
ImpresoraLinux miImpresora = new ImpresoraLinux();
miImpresora.ImprimirTicket();

public class ImpresoraLinux
{
    public void ImprimirTicket()
    {
        // Ruta del puerto USB en Linux
        string rutaImpresora = "/dev/usb/lp0"; 
        
        if (!File.Exists(rutaImpresora)) {
            rutaImpresora = "/dev/lp0";
        }

        try
        {
            using (FileStream fs = new FileStream(rutaImpresora, FileMode.Open, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs, Encoding.ASCII))
                {
                    // Comandos ESC/POS
                    writer.Write("\x1B\x40"); // Inicializar
                    
                    // Dentro de tu código C#, donde imprimes el ticket:
// Usamos string literals (@"") para mantener los saltos de línea

                    // Reemplaza el bloque de escritura anterior con este:

                    writer.WriteLine(" ______________________________ ");
                    writer.WriteLine("|                              |");
                    writer.WriteLine("|      TICKET DE HOSPITAL      |");
                    writer.WriteLine("|______________________________|");
                    writer.WriteLine("|                              |");
                    writer.WriteLine($"| Fecha: {DateTime.Now:dd/MM/yyyy HH:mm} |");
                    writer.WriteLine("|                              |");
                    writer.WriteLine("|       **************** |");
                    writer.WriteLine("|       * TURNO 23   * |");
                    writer.WriteLine("|       **************** |");
                    writer.WriteLine("|                              |");
                    writer.WriteLine("|      PASE DONDE EL DOC:      |");
                    writer.WriteLine("|       DR. RAMIREZ            |");
                    writer.WriteLine("|______________________________|");
                    writer.WriteLine("   ¡Gracias por su paciencia!   ");

// No olvides los saltos al final para que el papel salga
                    writer.WriteLine("\n\n\n\n");

// Y luego lo envías a la impresora:
                    writer.WriteLine("\n\n\n\n"); 
                    
                    writer.Flush();
                }
            }
            Console.WriteLine("¡Ticket enviado! Revisa la impresora.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("ERROR: No tienes permisos. Ejecuta en terminal: sudo chmod 666 /dev/usb/lp0");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
    }
}