<Query Kind="Program" />

	public class Term
{
	protected Term Left
	{
		get => _left ?? (_left = new Term());
		set
		{
			_left = value;
		}
	}
	
	protected Term Right
	{
		get => _right;
		set
		{
			_right = value;
		}
	}

	private Term _left;
	private Term _right;
	protected string stringRepresentation = "";
	
	protected object containedObject;
	
	    public Term(Term leftTerm, Term rightTerm)
	    {
	        this.Left = leftTerm;
	        this.Right = rightTerm;
	        MyLogger.Log("Term 2 args invoked");
	    }
	    
	    public Term(Term onlyTerm)
	    {
	        this.Left = onlyTerm;
	        this.Right = null;
	        MyLogger.Log("Term 1 arg invoked");
	    }
	    
	    private Term()
	    {
	        this.Left = this.Right = null;
	        MyLogger.Log("Term private constructor invoked");
	    }
	
	    public static Term EvaluateWith(Term[] args)
	    {
	        var term = BuildWith(args);
	        var pointer = term;
	        while (pointer.Right != null)
	        {
	            pointer.Reduce();
	            pointer = pointer.Right;
	        }
			MyLogger.Log(term.Stringify());
			return term;
	    }
		
		public string Stringify()
		{
			string result = "";
			int smileys = 0;
		var hero = this;

		while(true)
		{
			result += "(" + hero.stringRepresentation + ",";
			smileys++;
	
				if(!hero.HasRedex) break;
				hero = hero.Right;
			}
			while(smileys != 0)
			{
				result += ")";
				smileys--;
			}
			return result;
		}
		
		public Term Dump()
		{
			MyLogger.Log(Stringify());
			return this;
		}
	    
	    public static Term BuildWith(Term[] args)
	    {
	        if(args.Length == 0) return null;
	        var rootEntity = args.First();	
			for(int i = 0; i < args.Length; i++)
			{
				var next = (i + 1 < args.Length) ? args[i+1] : null;
				args[i].Right = next;
			}
	        return rootEntity;
	    }
		
		protected Term(string name)
		{
			stringRepresentation = name;
		}
		
	    protected Term(object value)
	    {
			stringRepresentation = value.ToString();
	        containedObject = value;
	    }
	
	    public bool HasRedex => _right != null;
	    
	    public virtual Term Reduce() => this;
		
	}
	
	public class Constant : Term
	{
	
	    public Constant(object value) : base(value)
	    {
	        MyLogger.Log("Constant public invoked");
	    }

	}
	
	public class Variable : Term
	{
	    public Variable(string name) : base(name)
	    {
	        MyLogger.Log("Variable public invoked");
	    }
	    
	}
	
	public class Applica: Term
	{
	    public Func<Applica, Term> action = defaultNoAction;
	    private static Term defaultNoAction(Term input) => input;
	    
	    public Term NextArgument => this.Right;
	    
	    public Applica(string funcName, Term argument) : base(funcName)
	    {
	        this.Right = argument;
	    }
		
		public override Term Reduce() => action(this);
	}
	
	public static class MyLogger
	{
	    public static void Log(string text) => text.Dump();
	}
	
	private static Term KCombinatorAction(Applica term)
	{
	    if (term.HasRedex && term.NextArgument.HasRedex) 
	    {
			var newTerm = term.NextArgument as Applica;
			newTerm.NextArgument
	        return term.NextArgument;
	    }
	    else return term;
	}
	
	void Main()
	{
	    var K = new Applica("K", null);
	    K.action = KCombinatorAction;
	    var one = new Constant("1");
	    var two = new Constant("2");

	var stmt = Term.BuildWith(new Term[] { K, one, two }).Dump();
	var stmt2 = Term.EvaluateWith(new Term[] { K, one, two }).Dump();


}
	
	
	// Define other methods and classes here
	

