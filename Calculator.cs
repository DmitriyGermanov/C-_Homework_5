namespace Homework_5;

internal class Calculator : ICalc
{
    private Stack<int> actions;
    public event EventHandler<EventArgs> GotResult;
    public int Result => actions.Peek();

    public Calculator()
    {
        actions = new Stack<int>(new int[] { 0 });
    }

    public void Add(int i)
    {
        Action(i, (a, b) => a + b);
    }

    public void Sub(int i)
    {
        Action(i, (a, b) => a - b);
    }

    public void Div(int i)
    {
        if (i == 0)
            throw new DivideByZeroException();
        Action(i, (a, b) => a / b);
    }

    public void Mul(int i)
    {
        Action(i, (a, b) => a * b);
    }

    public void CancelLast()
    {
        if (actions.Count > 1)
        {
            actions.Pop();
            OnGotResult();
        }
    }

    private void Action(int i, Func<int, int, int> operation)
    {
        int lastResult = actions.Peek();
        int newResult = operation(lastResult, i);
        actions.Push(newResult);
        OnGotResult();
    }

    protected virtual void OnGotResult()
    {
        GotResult?.Invoke(this, EventArgs.Empty);
    }
    public override string ToString()
    {
        return actions.Peek().ToString();
    }

}


