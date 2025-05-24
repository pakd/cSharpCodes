# Facade Pattern
The Facade Design Pattern is a structural design pattern that provides a unified and simplified interface to a set of interfaces in a subsystem. It hides the complexities of the subsystem and makes it easier for clients to interact with it.

# Example
```csharp

// subsystem classes
public class Projector
{
    public void On() => Console.WriteLine("Projector turned on.");
    public void Off() => Console.WriteLine("Projector turned off.");
}

public class Screen
{
    public void Lower() => Console.WriteLine("Screen lowered.");
    public void Raise() => Console.WriteLine("Screen raised.");
}

public class SoundSystem
{
    public void On() => Console.WriteLine("Sound system powered up.");
    public void SetVolume(int level) => Console.WriteLine($"Volume set to {level}.");
    public void Off() => Console.WriteLine("Sound system turned off.");
}

public class StreamingPlayer
{
    public void Play(string movie) => Console.WriteLine($"Now playing: {movie}");
    public void Stop() => Console.WriteLine("Playback stopped.");
}

// facade class
public class HomeTheaterFacade
{
    private readonly Projector _projector;
    private readonly Screen _screen;
    private readonly SoundSystem _soundSystem;
    private readonly StreamingPlayer _player;

    // Constructor to initialize all subsystems
    public HomeTheaterFacade(Projector projector, Screen screen, SoundSystem soundSystem, StreamingPlayer player)
    {
        _projector = projector;
        _screen = screen;
        _soundSystem = soundSystem;
        _player = player;
    }

    // A simple method to start watching a movie
    public void WatchMovie(string movie)
    {
        Console.WriteLine("\nSetting up home theater...");
        _screen.Lower();
        _projector.On();
        _soundSystem.On();
        _soundSystem.SetVolume(10);
        _player.Play(movie);
    }

    // A simple method to end the movie
    public void EndMovie()
    {
        Console.WriteLine("\nShutting down home theater...");
        _player.Stop();
        _soundSystem.Off();
        _projector.Off();
        _screen.Raise();
    }
}

// client code
class Program
{
    static void Main(string[] args)
    {
        // Create subsystem components
        var projector = new Projector();
        var screen = new Screen();
        var soundSystem = new SoundSystem();
        var player = new StreamingPlayer();

        // Use the facade to simplify the process of watching and ending a movie
        var homeTheater = new HomeTheaterFacade(projector, screen, soundSystem, player);

        homeTheater.WatchMovie("Inception");
        homeTheater.EndMovie();
    }
}

```

# Reference
1. https://www.youtube.com/watch?v=xWk6jvqyhAQ