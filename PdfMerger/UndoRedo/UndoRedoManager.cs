namespace PdfMerger.UndoRedo;

public class UndoRedoManager
{
    private readonly LinkedList<PdfProjectState> m_undo = new();
    private readonly LinkedList<PdfProjectState> m_redo = new();
    public int MaxHistory { get; set; } = 50;

    public UndoRedoManager()
    {
    }

    public void SaveState(PdfProjectState state)
    {
        m_undo.AddLast(state.Clone());
        m_redo.Clear();

        if (m_undo.Count > MaxHistory)
        {
            m_undo.RemoveFirst();
        }
    }

    public PdfProjectState Undo(PdfProjectState currentState)
    {
        if (m_undo.Count == 0)
        {
            return currentState;
        }

        if(m_undo.Last is null)
        {
            return currentState;
        }

        var last = m_undo.Last.Value;
        m_undo.RemoveLast();


        m_redo.AddLast(currentState.Clone());
        return last;
    }

    public PdfProjectState Redo(PdfProjectState currentState)
    {
        if (m_redo.Count == 0)
        {
            return currentState;
        }

        if (m_redo.Last is null)
        {
            return currentState;
        }

        var last = m_redo.Last.Value;
        m_redo.RemoveLast();

        m_undo.AddLast(currentState.Clone());
        return last;
    }

    public bool CanUndo => m_undo.Count > 0;
    public bool CanRedo => m_redo.Count > 0;
    public int UndoCount => m_undo.Count;
    public int RedoCount => m_redo.Count;
}
