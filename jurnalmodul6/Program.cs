// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    private string Username;

    public SayaTubeUser(string Username)
    {
        Debug.Assert(Username != null, "Username tidak boleh null");
        Debug.Assert(Username.Length <= 100, "Usernametidak boleh lebih dari 100 karakter");
        this.Username = Username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }
    public int GetTotalVideoPlayCount()
    {
        int totalPlayCount = 0;
        foreach (var video in uploadedVideos)
        {
            totalPlayCount += video.GetPlayCount();
        }
        return totalPlayCount;
    }
    public void AddVideo(SayaTubeVideo video)
    {
        Debug.Assert(video != null, "video yang ditambah tidak boleh null");
        Debug.Assert(video.GetPlayCount() <= int.MaxValue, "play count melibihi batas integer maksimum");
        uploadedVideos.Add(video);
    }
    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("User: " + this.Username);
        for(int i = 0; i < uploadedVideos.Count; i++)
        {
            Console.WriteLine("Video " + (i + 1) + " judul: " + uploadedVideos[i].GetTitle());
        }
    }
}

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(title != null, "Judul video tidak boleh null");
        Debug.Assert(title.Length <= 200, "Judul video tidak boleh lebih dari 200 karakter"); 
        Random random = new Random();
        this.id = new Random().Next(10000, 100000);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count > 0, "play count harus lebih dari nol");
        Debug.Assert(count <= 25000000, "play count maksimal 25.000.000");
        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Terjadi overflow pada penambahan play count");
        }
    }
    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID     : " + id);
        Console.WriteLine("Video Title  : " + title);
        Console.WriteLine("Play Count   : " + playCount);
    }
    public int GetPlayCount()
    {
        return this.playCount;
    }
    public string GetTitle()
    {
        return this.title;
    }
}
class Program
{
    static void Main(string[] args)
    {
        SayaTubeUser user = new SayaTubeUser("Deswita");
        SayaTubeVideo video1 = new SayaTubeVideo("Review Film Moana 2 oleh Deswita");
        SayaTubeVideo video2 = new SayaTubeVideo("Review Film Harry Potter oleh Deswita");
        SayaTubeVideo video3 = new SayaTubeVideo("Review Film Fantastic Beasts oleh Deswita");
        SayaTubeVideo video4 = new SayaTubeVideo("Review Film Sherlock Holmes oleh Deswita");
        SayaTubeVideo video5 = new SayaTubeVideo("Review Film Enola Holmes oleh Deswita");
        SayaTubeVideo video6 = new SayaTubeVideo("Review Film Avengers oleh Deswita");
        SayaTubeVideo video7= new SayaTubeVideo("Review Film Barbie oleh Deswita");
        SayaTubeVideo video8 = new SayaTubeVideo("Review Film Batman oleh Deswita");
        SayaTubeVideo video9 = new SayaTubeVideo("Review Film John Wick oleh Deswita");
        SayaTubeVideo video10 = new SayaTubeVideo("Review Film Extraction oleh Deswita");

        user.AddVideo(video1);
        user.AddVideo(video2);
        user.AddVideo(video3);
        user.AddVideo(video4);
        user.AddVideo(video5);
        user.AddVideo(video6);
        user.AddVideo(video7);
        user.AddVideo(video8);
        user.AddVideo(video9);
        user.AddVideo(video10);

        video1.IncreasePlayCount(100);
        video2.IncreasePlayCount(25000000);
        video3.IncreasePlayCount(1);
        video4.IncreasePlayCount(int.MaxValue);
        user.PrintAllVideoPlaycount();
        Console.WriteLine("Total Play Count: " + user.GetTotalVideoPlayCount());
    }
}
