namespace TestingLambda
{

    class Lambda
    {
        //delegates
        delegate int NumberOperation(int a, int b);
        static NumberOperation addNumbersDelegate = AddNumbers;
        static NumberOperation minusNumbersDelegate = SubTractNumbers;

        static void Main()
        {
            int a = 1;
            int b = 3;
            int c = 4;

            var addNumbers = AddNumbers(a, b);
            var minusNumbers = SubTractNumbers(c, a);

            //using named variable for method return
            Console.WriteLine("add using variable for result of method return: " + addNumbers);
            Console.WriteLine("minus using variable for result of method return: " + minusNumbers);

            //passing method directly as arguement
            Console.WriteLine("add using delegate in arguement: " + ProcessNumbers(AddNumbers, a, b, c));
            Console.WriteLine("minus using delegate in arguement: " + ProcessNumbers(SubTractNumbers, a, b, c));

            //using delegates
            Console.WriteLine("add using delegate in arguement: " + ProcessNumbersByDelegate(addNumbersDelegate, a,b,c) );
            Console.WriteLine("minus using delegate in arguement: " + ProcessNumbersByDelegate(minusNumbersDelegate, a, b, c) );

            //lambdas
            Func<int, int, int> lambdaAdd = (x, y) => x + y;
            Func<int, int, int> lambdaMinus = (x, y) => x - y;

            //passing lambda as paramater
            Console.WriteLine("add using Lambda as aparamater: " + ProcessNumbers(lambdaAdd, a, b, c));
            Console.WriteLine("minus using Lambda as paramater: " + ProcessNumbers(lambdaMinus, a, b, c));

            //delegate
            Func<int, int, int> delegateAdd = AddNumbers;
            Func<int, int, int> delegateMinus = SubTractNumbers;

            Console.WriteLine("add using delegate as aparamater: " + ProcessNumbers(delegateAdd, a, b, c));
            Console.WriteLine("minus using delegate as aparamater: " + ProcessNumbers(delegateMinus, a, b, c));

        }

        static int ProcessNumbers(Func<int, int, int> lambda, int a, int b, int c)
        {
            return lambda(a, b) + c;
        }

        static int ProcessNumbersByDelegate(NumberOperation operation, int a, int b, int c)
        {
            return operation(a, b) + c;
        }

        static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        static int SubTractNumbers(int a, int b)
        {
            return a - b;
        }



    }



}