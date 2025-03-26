// See https://aka.ms/new-console-template for more information
class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    private string Username;

    public SayaTubeUser(string Username)
    {
        Random random = new Random();
        this.id = new Random().Next(10000, 99999);
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
        if (video == null)
        {
            Console.WriteLine("Video tidak boleh kosong");
            return;
        }
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
        Random random = new Random();
        this.id = new Random().Next(10000, 100000);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int count)
    {
        if (count < 0)
        {
            Console.WriteLine("Jumlah play count tidak boleh negatif");
            return;
        }
        playCount += count;
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
        user.AddVideo(new SayaTubeVideo("Review Film Moana 2 oleh Deswita"));
        user.AddVideo(new SayaTubeVideo("Review Film Harry Potter oleh Deswita"));
        user.AddVideo(new SayaTubeVideo("Review Film Fantastic Beasts oleh Deswita"));
        user.AddVideo(new SayaTubeVideo("Review Film Sherlock Holmes oleh Deswita"));
        user.AddVideo(new SayaTubeVideo("Review Film Enola Holmes oleh Deswita"));
        user.AddVideo(new SayaTubeVideo("Review Film Avengers oleh Deswita"));
        user.AddVideo(new SayaTubeVideo("Review Film Barbie oleh Deswita"));
        user.AddVideo(new SayaTubeVideo("Review Film Batman oleh Deswita"));
        user.AddVideo(new SayaTubeVideo("Review Film John Wick oleh Deswita"));
        user.AddVideo(new SayaTubeVideo("Review Film Extraction oleh Deswita"));

        user.PrintAllVideoPlaycount();
        Console.WriteLine("Total Play Count: " + user.GetTotalVideoPlayCount());
        Console.ReadLine();
    }
}
