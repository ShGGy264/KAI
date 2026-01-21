using System.ComponentModel.DataAnnotations;
using System.Transactions;
using KAI;

namespace ActionFSA;

public delegate bool FSAAction(SimpleState from, SimpleState to);

public class ActionTransition: SimpleTransition {
    private FSAAction? action;

    public ActionTransition(string name, SimpleState to, FSAAction action=null) :base(name,to)
    {
        this.action = action;
    }

    public override SimpleState Do(SimpleState from)
    {
        if (this.action != null)
        {
            if (this.action(from, this._to))
            {
                return base.Do(from);
            }
        }
        return base.Do(from);
    }
}
    