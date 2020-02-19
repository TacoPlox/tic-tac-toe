using System;

namespace tic_tac_toe
{
    class Program
    {
        /// <summary>
        /// Matrix length
        /// </summary>
        static int MATRIX_SIZE = 3;
        //y, x
        //static char[,] matrix = new char[3, 3] {{'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'}};
        
        /// <summary>
        /// Matrix array [y, x]
        /// </summary>
        /// <value>Empty matrix</value>
        static char[,] matrix = new char[3, 3] {
            {' ', ' ', ' '}, 
            {' ', ' ', ' '}, 
            {' ', ' ', ' '}};

        /// <summary>
        /// Prints the matrix.
        /// </summary>
        static void PrintMatrix() {
            for (int y = 0; y < MATRIX_SIZE; y++) {
                string line = "";
                for (int x = 0; x < MATRIX_SIZE; x++) {
                    //Interpolate string
                    // Console.WriteLine($"[y, x] = {y}, {x}");
                    // Console.Write(matrix[y, x]);
                    line += matrix[y, x] + "|";
                }
                line = line.Substring(0, line.Length - 1);
                Console.WriteLine(line);
                Console.WriteLine("------");
            }
        }

        /// <summary>
        /// Adds a value to the matrix in the specified position.
        /// </summary>
        /// <param name="value">value to add</param>
        /// <param name="y">y position</param>
        /// <param name="x">x position</param>
        static void AddValue(char value, int y, int x) {
            matrix[y, x] = value;
        }

        static void InputRequest() {
            Console.WriteLine("Escribe las coordenadas de la forma y,x en donde quieres hacer tu movimiento y presiona enter.");
            string userInputCoordinates = Console.ReadLine();

            //Quitar espacios
            userInputCoordinates = userInputCoordinates.Replace(" ", "");

            //Separar en un arreglo de valores con ","
            string[] coordinates = userInputCoordinates.Split(",");

            //Convertir en coordenadas tipo entero
            int y = Convert.ToInt32(coordinates[0]);
            int x = Convert.ToInt32(coordinates[1]);

            AddValue('X', y, x);
        }

        static bool IsValueInMatrix(int y, int x) {
            bool isEmpty = matrix[y, x] == ' ';

            return !isEmpty;
        }

        static void AIRequest() {
            Random r = new Random();

            bool validPositionSelected = false;

            int y = 0;
            int x = 0;

            while(!validPositionSelected) {
                y = (int) Math.Floor(r.NextDouble() * 3);
                x = Convert.ToInt32(Math.Floor(r.NextDouble() * 3));
                bool isValueDefined = IsValueInMatrix(y, x);

                validPositionSelected = !isValueDefined;
            }

            AddValue('O', y, x);
        }

        static void Main(string[] args)
        {        
            PrintMatrix();
            InputRequest();
            AIRequest();
            PrintMatrix();


            // bool gameEnded = false;
            // int turns = 0;

            // while (!gameEnded) {
            //     InputRequest();
            //     turns++;
            //     //Check if user won
            //     gameEnded = CheckThreeLines();

            //     //End after 9 turns
            //     if (turns >= 9) {
            //         gameEnded = true;
            //     }

            //     if (!gameEnded) {
            //         //AIRequest();
            //         turns++;
            //         //Check if AI won
            //         gameEnded = CheckThreeLines();
            //     }
            // }
        }
    }
}
