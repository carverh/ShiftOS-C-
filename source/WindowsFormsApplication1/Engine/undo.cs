using System.Collections.Generic;
using System.Drawing;

public class undo
{
    public Stack<Image> undoStack = new Stack<Image>();
    public Stack<Image> redoStack = new Stack<Image>();
}