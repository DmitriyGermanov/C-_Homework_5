namespace Homework_5
{
    interface ICalc
    {
        event EventHandler<EventArgs> GotResult;
        void Add(int i);
        void Sub(int i);
        void Div(int i);
        void Mul(int i);
        void CancelLast();
    }

}
