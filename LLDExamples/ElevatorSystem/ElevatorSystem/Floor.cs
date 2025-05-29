namespace ElevatorSystem
{
    public class Floor
    {
        private int id;
        private Display display;
        private Button button;

        public Floor(int id)
        {
            this.id = id;
            button = new ExternalButton();
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public Display GetDisplay()
        {
            return display;
        }

        public void SetDisplay(Display display)
        {
            this.display = display;
        }

        public Button GetButton()
        {
            return button;
        }

        public void SetButton(Button button)
        {
            this.button = button;
        }

        public void PressButton(Direction dir)
        {
            button.PressButton(id, dir);
        }

        //called everytime selected elevator moves each floor
        private void SetDisplay(int floor, Direction dir)
        {
            display.SetDirection(dir);
            display.SetFloor(floor);
        }
    }
}