using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.Views;


namespace MauiApp1.ViewModels;

public partial class NotesViewModel : ObservableObject
{
    public ObservableCollection<Note> Notes { get; set; } = new();

    [ObservableProperty]
    string currentNoteText;

    public NotesViewModel()
    {
        LoadNotes();
    }

    private void LoadNotes()
    {
        Notes.Clear();
        string appDataPath = FileSystem.AppDataDirectory;

        var files = Directory.EnumerateFiles(appDataPath, "*.notes.txt");
        foreach (var file in files)
        {
            Notes.Add(new Note
            {
                Filename = file,
                Text = File.ReadAllText(file),                                                                                                             
                Date = File.GetCreationTime(file)
            });
        }
    }

    [RelayCommand]
    void SaveNote()
    {
        if (string.IsNullOrWhiteSpace(CurrentNoteText))
            return;

        string filename = Path.Combine(FileSystem.AppDataDirectory, $"{Path.GetRandomFileName()}.notes.txt");
        File.WriteAllText(filename, CurrentNoteText);

        Notes.Add(new Note
        {
            Filename = filename,
            Text = CurrentNoteText,
            Date = File.GetCreationTime(filename)
        });

        CurrentNoteText = string.Empty;
    }

    [RelayCommand]
    void DeleteAllNotes()
    {
        foreach (var note in Notes)
        {
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        Notes.Clear();
    }

}
