using Godot;
public partial class Case : TextureRect {
    public Case() {
        this.Connect("gui_input", new Callable(this, "_on_Carte_gui_input"));
    }

    private void _on_Carte_gui_input(InputEvent @event) {
        if( @event is InputEventMouseButton btn && @event.IsPressed() ) {
            GD.Print(this.Position);
            GD.Print(this.Name);            
        }
    }
}