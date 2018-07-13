using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using The_Composite_pattern;

namespace The_Composite_pattern
{
    #region LISTING 7-14 The composite implementation of an interface.
    public interface IComponent
    {
        EventHandler Event { get; set; }

        void Something();
        //EventHandler Event;
    }
    // . . .
    public class Leaf : IComponent
    {
        public EventHandler Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Something()
        {
        }
    }
    // . . .
    public class CompositeComponent : IComponent
    {
        public CompositeComponent()
        {
            children = new List<IComponent>();
        }

        public void AddComponent(IComponent component)
        {
            children.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            children.Remove(component);
        }

        public void Something()
        {
            foreach (var child in children)
            {
                child.Something();
            }
        }

        public void AlternativeComposite()
        {
            var composite = new CompositeComponent();
            composite.AddComponent(new Leaf());
            composite.AddComponent(new SecondTypeOfLeaf());
            composite.AddComponent(new AThirdLeafType());
            component = composite;
            composite.Something();
        }

        private ICollection<IComponent> children;
        private CompositeComponent component;

        public EventHandler Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    // . . .
    #endregion

    #region LISTING 7-15 Instances provided to the composite can be of different types.
    public class SecondTypeOfLeaf : IComponent
    {
        EventHandler IComponent.Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Something()
        {
        }

        void IComponent.Something()
        {
            throw new NotImplementedException();
        }
    }
    // . . .
    public class AThirdLeafType : IComponent
    {
        public EventHandler Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Something()
        {
        }
    }

    #endregion

    // Predicate decorators.
    #region LISTING 7-16 This client will execute only the Something method on even days of the month.
    public class DateTester
    {
        public bool TodayIsAnEvenDayOfTheMonth
        {
            get
            {
                return DateTime.Now.Day % 2 == 0;
            }
        }
    }
    // . . .
    //class PredicatedDecoratorExample
    //{
    //    public PredicatedDecoratorExample(IComponent component)
    //    {
    //        this.component = component;
    //    }
    //    public void Run()
    //    {
    //        DateTester dateTester = new DateTester();
    //        if (dateTester.TodayIsAnEvenDayOfTheMonth)
    //        {
    //            component.Something();
    //        }
    //    }
    //    private readonly IComponent component;
    //}
    #endregion

    #region LISTING 7-17 An improvement is to require the dependency to be passed into the class.
    //class PredicatedDecoratorExample
    //{
    //    public PredicatedDecoratorExample(IComponent component)
    //    {
    //        this.component = component;
    //    }
    //    public void Run(DateTester dateTester)
    //    {
    //        if (dateTester.TodayIsAnEvenDayOfTheMonth)
    //        {
    //            component.Something();
    //        }
    //    }
    //    private readonly IComponent component;
    //}
    #endregion

    #region LISTING 7-18 The predicate decoration contains the dependency, and the client is much cleaner.
    //public class PredicatedComponent : IComponent
    //{
    //    public PredicatedComponent(IComponent decoratedComponent, DateTester dateTester)
    //    {
    //        this.decoratedComponent = decoratedComponent;
    //        this.dateTester = dateTester;
    //    }
    //    public void Something()
    //    {
    //        if (dateTester.TodayIsAnEvenDayOfTheMonth)
    //        {
    //            decoratedComponent.Something();
    //        }
    //    }
    //    private readonly IComponent decoratedComponent;
    //    private readonly DateTester dateTester;
    // . . .
    class PredicatedDecoratorExample
    {
        public PredicatedDecoratorExample(IComponent component)
        {
            this.component = component;
        }
        public void Run()
        {
            component.Something();
        }
        private readonly IComponent component;
    }
    #endregion

    #region LISTING 7-19 Defining a dedicated IPredicate interface makes the solution more general.
    public interface IPredicate
    {
        bool Test();
    }
    // . . .

    public class PredicatedComponent : IComponent
    {
        public PredicatedComponent(IComponent decoratedComponent, IPredicate predicate)
        {
            this.decoratedComponent = decoratedComponent;
            this.predicate = predicate;
        }
        public void Something()
        {
            if (predicate.Test())
            {
                decoratedComponent.Something();
            }
        }
        private readonly IComponent decoratedComponent;
        private readonly IPredicate predicate;

        public EventHandler Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    // . . .
    public class TodayIsAnEvenDayOfTheMonthPredicate : IPredicate
    {
        public TodayIsAnEvenDayOfTheMonthPredicate(DateTester dateTester)
        {
            this.dateTester = dateTester;
        }
        public bool Test()
        {
            return dateTester.TodayIsAnEvenDayOfTheMonth;
        }
        private readonly DateTester dateTester;
    }
    #endregion

    // Branching decorators.
    #region LISTING 7-20 The branching decorator accepts two components and a predicate.
    public class BranchedComponent : IComponent
    {
        public BranchedComponent(IComponent trueComponent, IComponent falseComponent,
        IPredicate predicate)
        {
            this.trueComponent = trueComponent;
            this.falseComponent = falseComponent;
            this.predicate = predicate;
        }
        public void Something()
        {
            if (predicate.Test())
            {
                trueComponent.Something();
            }
            else
            {
                falseComponent.Something();
            }
        }
        private readonly IComponent trueComponent;
        private readonly IComponent falseComponent;
        private readonly IPredicate predicate;

        public EventHandler Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    #endregion

    // Lazy decorators.
    #region LISTING 7-21 This client has been given a Lazy<T>.
    //public class ComponentClient
    //{
    //    public ComponentClient(Lazy<IComponent> component)
    //    {
    //        this.component = component;
    //    }
    //    public void Run()
    //    {
    //        component.Value.Something();
    //    }
    //    private readonly Lazy<IComponent> component;
    //}
    #endregion

    #region LISTING 7-22 LazyComponent implements a lazily instantiated IComponent, but ComponentClient is unaware of this.
    public class LazyComponent : IComponent
    {
        public LazyComponent(Lazy<IComponent> lazyComponent)
        {
            this.lazyComponent = lazyComponent;
        }
        public void Something()
        {
            lazyComponent.Value.Something();
        }
        private readonly Lazy<IComponent> lazyComponent;

        public EventHandler Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    // . . .
    public class ComponentClient
    {
        public ComponentClient(IComponent component)
        {
            this.component = component;
        }
        public void Run()
        {
            component.Something();
        }
        private readonly IComponent component;
    }
    #endregion

    // Logging decorators.
    #region LISTING 7-24 Logging decorators factor out the logging code, simplifying the main implementation.

    public interface ICalculator
    {
        int Add(int x, int y);
    }

    public class LoggingCalculator : ICalculator
    {

        public LoggingCalculator(ICalculator calculator)
        {
            this.calculator = calculator;
        }
        public int Add(int x, int y)
        {
            Console.WriteLine("Add(x={0}, y={1})", x, y);
            var result = calculator.Add(x, y);
            Console.WriteLine("result={0}", result);
            return result;
        }
        private readonly ICalculator calculator;
    }


    // . . .
    public class ConcreteCalculator : ICalculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }

    #endregion

    // Profiling decorators.
    #region LISTING 7-25 This code is (intentionally and artificially) slow.
    //public class SlowComponent : IComponent
    //{
    //    public SlowComponent()
    //    {
    //        random = new Random((int)DateTime.Now.Ticks);
    //    }
    //    public void Something()
    //    {
    //        for (var i = 0; i < 100; ++i)
    //        {
    //            Thread.Sleep(random.Next(i) * 10);
    //        }
    //    }
    //    private readonly Random random;
    //}
    #endregion

    #region LISTING 7-26 The System.Diagnostics.Stopwatch class can time how long a method takes to execute.
    public class SlowComponent : IComponent
    {
        public SlowComponent()
        {
            random = new Random((int)DateTime.Now.Ticks);
            stopwatch = new Stopwatch();
        }
        public void Something()
        {
            stopwatch.Start();
            for (var i = 0; i < 30; ++i)
            {
                System.Threading.Thread.Sleep(random.Next(i) * 10);
            }
            stopwatch.Stop();
            Console.WriteLine("The method took {0} seconds to complete",
            stopwatch.ElapsedMilliseconds / 1000);
        }
        private readonly Random random;
        private readonly Stopwatch stopwatch;

        public EventHandler Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    #endregion

    #region LISTING 7-27 The profiling decorator code.
    //public class ProfilingComponent : IComponent
    //{
    //    public ProfilingComponent(IComponent decoratedComponent)
    //    {
    //        this.decoratedComponent = decoratedComponent;
    //        stopwatch = new Stopwatch();
    //    }
    //    public void Something()
    //    {
    //        stopwatch.Start();
    //        decoratedComponent.Something();
    //        stopwatch.Stop();
    //        Console.WriteLine("The method took {0} seconds to complete",
    //        stopwatch.ElapsedMilliseconds / 1000);
    //    }
    //    private readonly IComponent decoratedComponent;
    //    private readonly Stopwatch stopwatch;
    //}
    #endregion

    #region LISTING 7-28 Before you can implement a decorator, you must replace concrete implementations with interfaces.
    public class ProfilingComponent : IComponent
    {
        public ProfilingComponent(IComponent decoratedComponent, IStopwatch stopwatch)
        {
            this.decoratedComponent = decoratedComponent;
            this.stopwatch = stopwatch;
        }
        public void Something()
        {
            stopwatch.Start();
            decoratedComponent.Something();
            var elapsedMilliseconds = stopwatch.Stop();
            Console.WriteLine($"The method took {elapsedMilliseconds} seconds to complete");
        }
        private readonly IComponent decoratedComponent;
        private readonly IStopwatch stopwatch;

        public EventHandler Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


    #region LISTING 7-29 The LoggingStopwatch decorator is an IStopwatch implementation that logs and delegates.
    public class LoggingStopwatch : IStopwatch
    {
        public LoggingStopwatch(IStopwatch decoratedStopwatch)
        {
            this.decoratedStopwatch = decoratedStopwatch;
        }
        public void Start()
        {
            decoratedStopwatch.Start();
            Console.WriteLine("Stopwatch started...");
        }
        public long Stop()
        {
            var elapsedMilliseconds = decoratedStopwatch.Stop();
            Console.WriteLine("Stopwatch stopped after {0} seconds",
            TimeSpan.FromMilliseconds(Convert.ToDouble(elapsedMilliseconds)).TotalSeconds);
            return Convert.ToInt64(elapsedMilliseconds);
        }

        void IStopwatch.Start()
        {
            throw new NotImplementedException();
        }

        object IStopwatch.Stop()
        {
            throw new NotImplementedException();
        }

        private readonly IStopwatch decoratedStopwatch;
    }
    #endregion

    public interface IStopwatch
    {
        void Start();
        object Stop();
    }
    #endregion

    #region LISTING 7-30 The primary IStopwatch implementation uses the Stopwatch class.
    public class StopwatchAdapter : IStopwatch
    {
        public StopwatchAdapter(Stopwatch stopwatch)
        {
            this.stopwatch = stopwatch;
        }
        public void Start()
        {
            stopwatch.Start();
        }
        public long Stop()
        {
            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            return elapsedMilliseconds;
        }

        void IStopwatch.Start()
        {
            throw new NotImplementedException();
        }

        object IStopwatch.Stop()
        {
            throw new NotImplementedException();
        }

        private readonly Stopwatch stopwatch;
    }
    #endregion

    #region LISTING 7-31 Properties can also use the Decorator pattern, just like methods.
    //public class ComponentDecorator : IComponent
    //{
    //    public ComponentDecorator(IComponent decoratedComponent)
    //    {
    //        this.decoratedComponent = decoratedComponent;
    //    }
    //    public string Property
    //    {
    //        get
    //        {
    //            // We can do some mutation here after retrieving the value
    //            return decoratedComponent.Property;
    //        }
    //        set
    //        {
    //            // And/or here, before we set the value
    //            decoratedComponent.Property = value;
    //        }
    //    }
    //    private readonly IComponent decoratedComponent;
    //}
    #endregion

    #region LISTING 7-32 Events can also use the Decorator pattern, just like methods.
    public class ComponentDecorator : IComponent
    {
        public ComponentDecorator(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }
        public event EventHandler Event
        {
            add
            {
                // We can do something here, when the event handler is registered
                decoratedComponent.Event += value;
            }
            remove
            {
                // And/or here, when the event handler is deregistered
                decoratedComponent.Event -= value;
            }
        }
        private readonly IComponent decoratedComponent;

        EventHandler IComponent.Event { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Something()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            SlowComponent s = new SlowComponent();
            s.Something();
            Console.ReadLine();
        }
    }
}
