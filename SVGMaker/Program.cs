//VSCODE WINDOWS 11
using System;
using System.Diagnostics;
public class main{
    public HashSet<string> idHashSet = new HashSet<string>();
    public static void Main(string[] args){
        Canvas c1 = new Canvas(1000,1000);

        shapes s1 = new circle(40, 500, 500, "white", "3", "blue");
        shapes s2 = new rectangle(10,10, 50, 75, "white", "3", "purple");
        shapes s3 = new ellipse(50,30,70,70,"white", "3", "blue");
        shapes s4 = new line(650, 650, 800, 800, "yellow", "30");


        c1.addShape(s1);
        c1.addShape(s2);
        c1.addShape(s3);
        c1.addShape(s4);

        c1.removeShape(s3.getID());

        c1.updateShape(s1.getID(), new polyGon());

        File.WriteAllTextAsync("fin.svg", c1.getSVG());
    }
}

class Canvas : main{
    private string svg;
    private int order = 0;
    //Dictionary<int, shapes> elements = new Dictionary<string, shapes>();
    private List<shapes> els = new List<shapes>();
    private int width, height;
    public Canvas(int width, int height){
        this.width = width;
        this.height = height;
        svg = "<svg height=\"" + this.height +"\"" + " width=\"" + this.width + "\"" + ">\n";
    }

    public void addShape(shapes s){
        idHashSet.Add(s.getID());
        els.Add(s);
        order++;
        reBuildSvg(els);
    }
    public void removeShape(string id){
        idHashSet.Remove(id);
        for(int i = 0; i < els.Count; i++){
            if(els[i].getID() == id){
                els.RemoveAt(i);
                order--;
                break;
            }
        }
        reBuildSvg(els);
    }

    public void updateShape(string id, shapes s){
        idHashSet.Remove(id);
        idHashSet.Add(s.getID());

        for(int i = 0; i < els.Count; i++){
            if(els[i].getID() == id){
                els[i] = s;
                break;
            }
        }
        reBuildSvg(els);
    }

    public void reBuildSvg(List<shapes> els){
        svg = "<svg height=\"" + this.height +"\"" + " width=\""+ this.width + "\"" + ">\n";
        if(order != 0){
            for(int i = 0; i < order; i++){
                svg = svg + els[i].getSVG();
            }
        }
        svg = svg + "</svg>";
    }

    public string getSVG(){
        return svg;
    }

    public int getOrder(){
        return order;
    }
}

class shapes{
    public virtual string getSVG(){    
        return "svg code";
    }

    public virtual string getID(){
        return "ID";
    }
}

class circle : shapes{
    private int r, cx, cy;
    private string ID, stroke, strokewidth, fill;
    public circle(){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString(); 

        this.r = 1;
        this.cx = 10;
        this.cy = 10;
        this.stroke = "black";
        this.strokewidth = "10";
        this.fill = "blue";
    }

    public circle(int rad, int cx, int cy, string stroke, string strokewidth, string fill){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();

        this.fill = fill;
        this.stroke = stroke;
        this.strokewidth = strokewidth;
        this.r = rad;
        this.cx = cx;
        this.cy = cy;   
    }

    public override string getSVG(){
        return "<circle cx=\""+ this.cx + "\" " + "cy=\"" + this.cy + "\" " + "r=\"" + this.r + "\"" + " stroke=\"" + this.stroke + "\" stroke-width=\"" +   this.strokewidth +  "\" fill=\"" + this.fill + "\"/>\n";
    }

    public override string getID(){
        return ID;
    }
}

class rectangle : shapes{
    private string ID, fill, strokewidth, stroke;
    private int x, y , width, height;
    public rectangle(){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();

        this.x = 10;
        this.y = 10;
        this.width = 15;
        this.height = 10;
        this.stroke = "black";
        this.strokewidth = "10";
        this.fill = "blue";
    }

    public rectangle(int x, int y, int width, int height, string stroke, string strokewidth, string fill){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();

        this.fill = fill;
        this.stroke = stroke;
        this.strokewidth = strokewidth;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public override string getSVG(){
        return "<rect x=\""+ this.x + "\" " + "y=\"" + this.y + "\" " + "width=\"" + this.width + "\" " + "height=\"" + this.height + "\" " + " stroke=\"" + this.stroke + "\" stroke-width=\"" +   this.strokewidth +  "\" fill=\"" + this.fill + "\"/>\n";
    }

    public override string getID(){
        return ID;
    }
}

class ellipse : shapes{
    private string ID, fill, stroke, strokewidth;
    private int rx, ry, cx, cy;

    public ellipse(){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();

        this.rx = 10;
        this.ry = 15;
        this.cx = 10;
        this.cy = 10;
        this.stroke = "black";
        this.strokewidth = "10";
        this.fill = "blue";
    }

    public ellipse(int rx, int ry, int cx, int cy, string stroke, string strokewidth, string fill){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();

        this.rx = rx;
        this.ry = ry;
        this.cx = cx;
        this.cy = cy;
        this.fill = fill;
        this.stroke = stroke;
        this.strokewidth = strokewidth;
    }

    public override string getSVG(){
       return "<ellipse cx=\""+ this.cx + "\" " + "cy=\"" + this.cy + "\" " + "rx=\"" + this.rx + "\" " + "ry=\"" + this.ry + "\" " + " stroke=\"" + this.stroke + "\" stroke-width=\"" +   this.strokewidth +  "\" fill=\"" + this.fill + "\"/>\n";
   }

    public override string getID(){
        return ID;
    }
}

class line : shapes{
    private string ID, stroke, strokewidth;
    private int x1, y1, x2, y2;

    public line(){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();

        this.x1 = 10;
        this.y1 = 10;
        this.x2 = 30;
        this.y2 = 30;
        this.stroke = "black";
        this.strokewidth = "10";
    }

    public line(int x1, int y1, int x2, int y2, string stroke, string strokewidth){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();
        
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.stroke = stroke;
        this.strokewidth = strokewidth;
    }

    public int getx1(){
        return this.x1;
    }

    public int gety1(){
        return this.y1;
    }

    public int getx2(){
        return this.x2;
    }

    public int gety2(){
        return this.y2;
    }

    public override string getSVG(){
       return "<line x1=\""+ this.x1 + "\" " + "y1=\"" + this.y1 + "\" " + "x2=\"" + this.x2 + "\" " + "y2=\"" + this.y2 + "\" " + "stroke=\"" + this.stroke + "\" stroke-width=\"" +   this.strokewidth + "\"/>\n";
    }

    public override string getID(){
        return ID;
    }
}

class polyLine : shapes{
    private string ID, order = "", stroke, strokewidth;

    public polyLine(){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();
        this.stroke = "black";
        this.strokewidth = "10";
        this.order = "1,1 2,2 3,3 4,4 5,5";
    }
    public polyLine(List<line> l, string stroke, string strokewidth){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();
        this.stroke = stroke;
        this.strokewidth = strokewidth;

        for(int i = 0; i < l.Count; i++){
            order = order + l[i].getx1() + "," + l[i].gety1() + " ";
        }
        order = order + l[l.Count - 1].getx2() + "," + l[l.Count - 1].gety2();
    }
    public override string getSVG(){
       return "<polyline points=\""+ this.order + "\" " + " stroke=\"" + this.stroke + "\" stroke-width=\"" +   this.strokewidth + "\"/>\n";
   }

    public override string getID(){
        return ID;
    }
}

class polyGon : shapes{
    private string ID, order = "", stroke, strokewidth, fill;
    public polyGon(){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();
        this.stroke = "black";
        this.strokewidth = "1";
        this.fill = "blue";
        this.order = "200,10 250,190 160,210";
    }
    public polyGon(List<line> l, string stroke, string strokewidth, string fill){
        Guid myuuid = Guid.NewGuid();
        this.ID = myuuid.ToString();
        this.stroke = stroke;
        this.strokewidth = strokewidth;
        this.fill = fill;

        for(int i = 0; i < l.Count; i++){
            order = order + l[i].getx1() + "," + l[i].gety1() + " ";
        }
        order = order + l[l.Count - 1].getx2() + "," + l[l.Count - 1].gety2();
    }
    public override string getSVG(){
       return "<polygon points=\""+ this.order + "\" " + " stroke=\"" + this.stroke + "\" stroke-width=\"" +   this.strokewidth +  "\" fill=\"" + this.fill + "\"/>\n";
   }

    public override string getID(){
        return ID;
    }
}