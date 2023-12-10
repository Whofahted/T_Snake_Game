using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class SnakeGame : Form
    {
        // Represents the snake as a list of points
        private List<Point> snake = new List<Point>();

        // Represents the position of the food
        private Point food;

        // Represents the obstacles on the game area
        private List<Point> obstacles = new List<Point>();

        // Represents the direction of the snake (0: right, 1: down, 2: left, 3: up)
        private int direction = 0;

        // Represents the player's score
        private int score = 0;

        // Defines the size of each grid cell in the game area
        private const int gridSize = 30;

        // Defines the interval for the game timer (controls snake speed and difficulty)
        private const int timerInterval = 200;

        // Timer object to control the game loop
        private Timer gameTimer;

        // Random object for generating random positions
        private Random random = new Random();

        public SnakeGame()
        {
            InitializeComponent();
            InitializeGame();
        }

        // Initializes the game state
        private void InitializeGame()
        {
            snake.Clear();
            snake.Add(new Point(50, 50)); // Initial position of the snake
            GenerateFood();
            GenerateObstacles();
            direction = 0;
            score = 0;
        }

        // Generates a random position for the food
        private void GenerateFood()
        {
            Random random = new Random();
            int maxX = gameAreaPictureBox.Width / gridSize;
            int maxY = gameAreaPictureBox.Height / gridSize;

            food = AlignToGrid(new Point(random.Next(0, maxX) * gridSize, random.Next(0, maxY) * gridSize));
        }

        // Generates a random number of obstacles with random positions
        private void GenerateObstacles()
        {
            int obstacleCount = random.Next(3, 10);

            obstacles.Clear();

            for (int i = 0; i < obstacleCount; i++)
            {
                int maxX = gameAreaPictureBox.Width / gridSize;
                int maxY = gameAreaPictureBox.Height / gridSize;

                Point obstacle = AlignToGrid(new Point(random.Next(0, maxX) * gridSize, random.Next(0, maxY) * gridSize));

                // Ensure the obstacle is not generated on the snake or food
                while (obstacles.Contains(obstacle) || snake.Contains(obstacle) || obstacle == food)
                {
                    obstacle = AlignToGrid(new Point(random.Next(0, maxX) * gridSize, random.Next(0, maxY) * gridSize));
                }

                obstacles.Add(obstacle);
            }
        }

        // Aligns a point to the nearest grid position
        private Point AlignToGrid(Point point)
        {
            int x = (int)(Math.Round((double)point.X / gridSize) * gridSize);
            int y = (int)(Math.Round((double)point.Y / gridSize) * gridSize);
            return new Point(x, y);
        }

        // Handles the game timer tick event
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            CheckFood();
            gameAreaPictureBox.Invalidate();
        }

        // Moves the snake based on the current direction
        private void MoveSnake()
        {
            Point head = snake.First();
            Point newHead;

            switch (direction)
            {
                case 0: // Right
                    newHead = new Point((head.X + gridSize) % gameAreaPictureBox.Width, head.Y);
                    break;
                case 1: // Down
                    newHead = new Point(head.X, (head.Y + gridSize) % gameAreaPictureBox.Height);
                    break;
                case 2: // Left
                    newHead = new Point((head.X - gridSize + gameAreaPictureBox.Width) % gameAreaPictureBox.Width, head.Y);
                    break;
                case 3: // Up
                    newHead = new Point(head.X, (head.Y - gridSize + gameAreaPictureBox.Height) % gameAreaPictureBox.Height);
                    break;
                default:
                    throw new InvalidOperationException("Invalid direction");
            }

            snake.Insert(0, AlignToGrid(newHead));

            if (newHead == food)
            {
                score++;
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        // Checks for collisions with obstacles or the snake itself
        private void CheckCollision()
        {
            Point head = snake.First();

            // Check collision with self or obstacles
            if (snake.Skip(1).Any(segment => segment == head) || obstacles.Contains(head))
            {
                StopGame();
            }
        }

        // Checks if the snake has eaten the food
        private void CheckFood()
        {
            Point head = snake.First();
            if (head == food)
            {
                score++;
                GenerateFood();
            }
        }

        // Handles the painting of the game area
        private void gameAreaPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.DarkGray);

            // Draw obstacles
            foreach (Point obstacle in obstacles)
            {
                g.FillRectangle(Brushes.Gray, obstacle.X, obstacle.Y, gridSize, gridSize);
            }

            // Draw snake
            foreach (Point segment in snake)
            {
                g.FillRectangle(Brushes.DarkGreen, segment.X, segment.Y, gridSize, gridSize);
            }

            // Draw food
            g.FillRectangle(Brushes.Red, food.X, food.Y, gridSize, gridSize);
        }

        // Handles key presses for changing the snake direction
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (direction != 2)
                        direction = 0;
                    break;
                case Keys.Down:
                    if (direction != 3)
                        direction = 1;
                    break;
                case Keys.Left:
                    if (direction != 0)
                        direction = 2;
                    break;
                case Keys.Up:
                    if (direction != 1)
                        direction = 3;
                    break;
                case Keys.Escape:
                    StopGame();
                    break;
            }
        }

        // Stops the game and displays a message with the player's score
        private void StopGame()
        {
            gameTimer.Stop();
            MessageBox.Show("Game Stopped! Your score: " + score, "Game Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InitializeGame();
            startButton.Enabled = true;
        }

        // Initializes the form and sets up event handlers
        private void Form1_Load(object sender, EventArgs e)
        {
            gameTimer = new Timer { Interval = timerInterval };
            gameTimer.Tick += gameTimer_Tick;

            this.KeyDown += Form1_KeyDown;

            gameAreaPictureBox.Paint += gameAreaPictureBox_Paint;
            // Handle the selection change event
            difficultyComboBox.SelectedIndexChanged += difficultyComboBox_SelectedIndexChanged;

            this.Invalidate();
        }

        // Event handler for difficulty selection change
        private void difficultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can add logic here if needed
        }

        // Prevents typing in the difficultyComboBox
        private void difficultyComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        // Handles the click event for the start button
        private void startButton_Click(object sender, EventArgs e)
        {
            InitializeGame();
            // Get the selected difficulty from existing ComboBox
            string selectedDifficulty = difficultyComboBox.SelectedItem?.ToString();

            // Check if a difficulty is selected
            if (!string.IsNullOrEmpty(selectedDifficulty))
            {
                // Set timer interval based on the selected difficulty
                switch (selectedDifficulty)
                {
                    case "Easy":
                        gameTimer.Interval = 200;
                        break;
                    case "Medium":
                        gameTimer.Interval = 150;
                        break;
                    case "Hard":
                        gameTimer.Interval = 100;
                        break;
                    case "Insane":
                        gameTimer.Interval = 50;
                        break;
                    default:
                        gameTimer.Interval = 150; // Default to Medium if unexpected value
                        break;
                }

                gameTimer.Start();
                startButton.Enabled = false;
                gameAreaPictureBox.Focus();
            }
            else
            {
                MessageBox.Show("Please select a difficulty before starting the game.", "Missing Difficulty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}