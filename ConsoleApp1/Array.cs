namespace ConsoleApp1
{
    internal class Array : IOutput2, ICalc2
    {
        private int[] _numbers;

        public Array(int[] numbers)
        {
            _numbers = numbers;
        }


        #region Davaleba N1
        public void ShowEven()
        {
            for (int i = 0; i < _numbers.Length; i++)
            {
                if (_numbers[i] % 2 == 0) { 
                    Console.Write(_numbers[i] + " ");
                }
            }
        }

        public void ShowOdd()
        {
            for (int i = 0; i < _numbers.Length; i++)
            {
                if (_numbers[i] % 2 != 0) { 
                    Console.Write(_numbers[i] + " ");
                }
            }
        }
        #endregion

        #region Davaleba N2
        public int CountDistinct()
        {
            int count = 0;

            for (int i = 0; i < _numbers.Length; i++)
            {
                bool isRepeated = false;

                for (int j = 0; j < i; j++)
                {
                    if (_numbers[j] == _numbers[i])
                    {
                        isRepeated = true;
                        break;
                    }
                }

                if (!isRepeated) { 
                    count++;
                }
            }

            return count;
        }

        public int EqualToValue(int valueToCompare)
        {
            int count = 0;

            for (int i = 0; i < _numbers.Length; i++)
            {
                if (_numbers[i] == valueToCompare)
                {
                    count++;
                }
            }

            return count;
        }

        #endregion
    }
}
