using Godot;
public class Case : TextureRect {
    public Case() {
        this.Connect("gui_input", this, "_on_Carte_gui_input");
    }

    private void _on_Carte_gui_input(InputEvent @event) {
        if( @event is InputEventMouseButton btn && btn.ButtonIndex == (int)ButtonList.Left && @event.IsPressed() ) {
            GD.Print(this.RectPosition);
            GD.Print(this.Name);            
        }
    }
}