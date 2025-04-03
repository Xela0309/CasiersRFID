using testlecteur;

class Program
{
    static void Main()
    {
        classLecteur lecteur = new classLecteur("COM8", 9600);
        lecteur.OpenPort();
        lecteur.lireTag();
        Console.WriteLine("Tag : " + lecteur.GetTag());

    }
}


