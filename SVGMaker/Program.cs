//VSCODE WINDOWS 11
//David Ochinca-Beregoi
using System;
using System.Diagnostics;
public class main{
    public static HashSet<string> idHashSet = new HashSet<string>();
    public static void Main(string[] args){
        Console.WriteLine("Input height and width of canvas");
        int h11 = Int32.Parse(Console.ReadLine());
        int w11 = Int32.Parse(Console.ReadLine());
        Canvas c1 = new Canvas(h11,w11);

        shapes tempShape = new shapes();
        
        while(true){
            Console.WriteLine("Input 1 for adding shape\nInput 2 for deleting shape\nInput 3 for updating shape\nInput 9 to exit");
            int x = Int32.Parse(Console.ReadLine());
            if(x == 9){
                File.WriteAllTextAsync("fin.svg", c1.getSVG());
                break;
            } 
            switch(x){
                case 1:
                    Console.WriteLine("Input 1 for circle\n2 for rectangle\n3 for ellipse\n4 for line\n5for polyline\n6 for polygon");
                    int y = Int32.Parse(Console.ReadLine());
                    switch(y){
                        case 1:
                            Console.WriteLine("Input: Radius, cx, cy, stroke, strokewidth, fill");
                            int r = Int32.Parse(Console.ReadLine());
                            int cx = Int32.Parse(Console.ReadLine());
                            int cy = Int32.Parse(Console.ReadLine());
                            string str = Console.ReadLine();
                            string strw = Console.ReadLine();
                            string fill1 = Console.ReadLine();
                            tempShape = new circle(r,cx,cy,str,strw,fill1);
                            Console.WriteLine("ShapeID of shape added: " + tempShape.getID());
                            c1.addShape(tempShape);
                            File.WriteAllTextAsync("fin.svg", c1.getSVG());
                            
                        break;
                        case 2:
                            Console.WriteLine("Input: x, y, width, height, stroke, strokewidth, fill");
                            cx = Int32.Parse(Console.ReadLine());
                            cy = Int32.Parse(Console.ReadLine());
                            int w = Int32.Parse(Console.ReadLine());
                            int h = Int32.Parse(Console.ReadLine());
                            str = Console.ReadLine();
                            strw = Console.ReadLine();
                            fill1 = Console.ReadLine();
                            tempShape = new rectangle(cx,cy,w,h,str,strw,fill1);
                            Console.WriteLine("ShapeID of shape added: " + tempShape.getID());
                            c1.addShape(tempShape);
                            File.WriteAllTextAsync("fin.svg", c1.getSVG());
                        break;
                        case 3:
                            Console.WriteLine("Input: rx, ry, cx, cy, stroke, strokewidth, fill");
                            int rx = Int32.Parse(Console.ReadLine());
                            int ry = Int32.Parse(Console.ReadLine());
                            cx = Int32.Parse(Console.ReadLine());
                            cy = Int32.Parse(Console.ReadLine());
                            str = Console.ReadLine();
                            strw = Console.ReadLine();
                            fill1 = Console.ReadLine();
                            tempShape = new ellipse(rx,ry,cx,cy,str,strw,fill1);
                            Console.WriteLine("ShapeID of shape added: " + tempShape.getID());
                            c1.addShape(tempShape);
                            File.WriteAllTextAsync("fin.svg", c1.getSVG());
                        break;
                        case 4:
                            Console.WriteLine("Input: x1, y1, x2, y2, stroke, strokewidth");
                            rx = Int32.Parse(Console.ReadLine());
                            ry = Int32.Parse(Console.ReadLine());
                            cx = Int32.Parse(Console.ReadLine());
                            cy = Int32.Parse(Console.ReadLine());
                            str = Console.ReadLine();
                            strw = Console.ReadLine();
                            tempShape = new line(rx,ry,cx,cy,str,strw);
                            Console.WriteLine("ShapeID of shape added: " + tempShape.getID());
                            c1.addShape(tempShape);
                            File.WriteAllTextAsync("fin.svg", c1.getSVG());
                        break;
                        case 5:
                            Console.WriteLine("Input: stroke, strokewidth");
                            string st = Console.ReadLine();
                            string stw = Console.ReadLine();

                            List<line> l = new List<line>();

                            Console.WriteLine("Input: x1, y1, x2, y2, of every line you want");
                            while(true){
                                Console.WriteLine("x1: ");
                                int x1 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("y1: ");
                                int y1 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("x2: ");
                                int x2 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("y2: ");
                                int y2 = Int32.Parse(Console.ReadLine());
                                line tempLine = new line(x1, y1, x2, y2, st, stw);
                                l.Add(tempLine);
                                Console.WriteLine("Input: 9 to exit, 1 to continue");
                                int t = Int32.Parse(Console.ReadLine());
                                if(t == 9){
                                    break;
                                }
                                Console.WriteLine("Next Line!");
                            }
                            tempShape = new polyLine(l, st, stw);
                            Console.WriteLine("ShapeID of shape added: " + tempShape.getID());
                            c1.addShape(tempShape);
                            File.WriteAllTextAsync("fin.svg", c1.getSVG());
                        break;
                        case 6:
                            Console.WriteLine("Input: stroke, strokewidth, fill");
                            string st2 = Console.ReadLine();
                            string stw2 = Console.ReadLine();
                            string fill = Console.ReadLine();

                            List<line> l2 = new List<line>();

                            Console.WriteLine("Input: x1, y1, x2, y2, of every line you want");
                            while(true){
                                Console.WriteLine("x1: ");
                                int x1 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("y1: ");
                                int y1 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("x2: ");
                                int x2 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("y2: ");
                                int y2 = Int32.Parse(Console.ReadLine());
                                line tempLine1 = new line(x1, y1, x2, y2, st2, stw2);
                                l2.Add(tempLine1);
                                Console.WriteLine("Input: 9 to exit, 1 to continue");
                                int t = Int32.Parse(Console.ReadLine());
                                if(t == 9){
                                    break;
                                }
                                Console.WriteLine("Next Line!");
                            }
                            tempShape = new polyGon(l2, st2, stw2, fill);
                            Console.WriteLine("ShapeID of shape added: " + tempShape.getID());
                            c1.addShape(tempShape);
                            File.WriteAllTextAsync("fin.svg", c1.getSVG());                        
                        break;
                    }

                break;
                case 2:
                    Console.WriteLine("Input 1 to delete by Z Index \n Input 2 to delete by shapeID");
                    int tt = Int32.Parse(Console.ReadLine());
                    switch(tt){
                        case 1:
                            Console.WriteLine("Input the Z index for deletion");
                            tt = Int32.Parse(Console.ReadLine());
                            c1.removeShape(tt);
                            File.WriteAllTextAsync("fin.svg", c1.getSVG());   
                        break;
                        case 2:
                            Console.WriteLine("Input the shapeID for deletion");
                            string[] idHashSetARR = new string[idHashSet.Count];
                            idHashSetARR = idHashSet.ToArray<string>();
                            for(int i = 0; i < idHashSet.Count; i++){
                                Console.WriteLine(idHashSetARR[i]);
                            }

                            string idtemp = Console.ReadLine();
                            c1.removeShape(idtemp);
                            File.WriteAllTextAsync("fin.svg", c1.getSVG());   
                        break;
                    }
                break;
                case 3:
                    Console.WriteLine("Input ShapeID to be updated");
                    string hh = Console.ReadLine();


                    Console.WriteLine("Input 1 for circle\n2 for rectangle\n3 for ellipse\n4 for line\n5for polyline\n6 for polygon");
                    int uy = Int32.Parse(Console.ReadLine());

                    switch(uy){
                        case 1:
                            Console.WriteLine("Input: Radius, cx, cy, stroke, strokewidth, fill");
                            int r = Int32.Parse(Console.ReadLine());
                            int cx = Int32.Parse(Console.ReadLine());
                            int cy = Int32.Parse(Console.ReadLine());
                            string str = Console.ReadLine();
                            string strw = Console.ReadLine();
                            string fill1 = Console.ReadLine();
                            tempShape = new circle(r,cx,cy,str,strw,fill1); 
                        break;
                        case 2:
                            Console.WriteLine("Input: x, y, width, height, stroke, strokewidth, fill");
                            cx = Int32.Parse(Console.ReadLine());
                            cy = Int32.Parse(Console.ReadLine());
                            int w = Int32.Parse(Console.ReadLine());
                            int h = Int32.Parse(Console.ReadLine());
                            str = Console.ReadLine();
                            strw = Console.ReadLine();
                            fill1 = Console.ReadLine();
                            tempShape = new rectangle(cx,cy,w,h,str,strw,fill1);
                            
                        break;
                        case 3:
                            Console.WriteLine("Input: rx, ry, cx, cy, stroke, strokewidth, fill");
                            int rx = Int32.Parse(Console.ReadLine());
                            int ry = Int32.Parse(Console.ReadLine());
                            cx = Int32.Parse(Console.ReadLine());
                            cy = Int32.Parse(Console.ReadLine());
                            str = Console.ReadLine();
                            strw = Console.ReadLine();
                            fill1 = Console.ReadLine();
                            tempShape = new ellipse(rx,ry,cx,cy,str,strw,fill1);
                            
                        break;
                        case 4:
                            Console.WriteLine("Input: x1, y1, x2, y2, stroke, strokewidth");
                            rx = Int32.Parse(Console.ReadLine());
                            ry = Int32.Parse(Console.ReadLine());
                            cx = Int32.Parse(Console.ReadLine());
                            cy = Int32.Parse(Console.ReadLine());
                            str = Console.ReadLine();
                            strw = Console.ReadLine();
                            tempShape = new line(rx,ry,cx,cy,str,strw);
                            
                        break;
                        case 5:
                            Console.WriteLine("Input: stroke, strokewidth");
                            string st = Console.ReadLine();
                            string stw = Console.ReadLine();

                            List<line> l = new List<line>();

                            Console.WriteLine("Input: x1, y1, x2, y2, of every line you want");
                            while(true){
                                Console.WriteLine("Input: 9 to exit, 1 to continue");
                                int t = Int32.Parse(Console.ReadLine());
                                if(x == 9) break;
                                Console.WriteLine("x1: ");
                                int x1 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("y1: ");
                                int y1 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("x2: ");
                                int x2 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("y2: ");
                                int y2 = Int32.Parse(Console.ReadLine());
                                line tempLine = new line(x1, y1, x2, y2, st, stw);
                                l.Add(tempLine);
                                Console.WriteLine("Input: 9 to exit, 1 to continue");
                                t = Int32.Parse(Console.ReadLine());
                                    if(t == 9){
                                    break;
                                }
                                Console.WriteLine("Next Line!");
                            }
                            tempShape = new polyLine(l, st, stw);
                            
                        break;
                        case 6:
                            Console.WriteLine("Input: stroke, strokewidth, fill");
                            string st2 = Console.ReadLine();
                            string stw2 = Console.ReadLine();
                            string fill = Console.ReadLine();

                            List<line> l2 = new List<line>();

                            Console.WriteLine("Input: x1, y1, x2, y2, of every line you want");
                            while(true){
                                Console.WriteLine("x1: ");
                                int x1 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("y1: ");
                                int y1 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("x2: ");
                                int x2 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("y2: ");
                                int y2 = Int32.Parse(Console.ReadLine());
                                line tempLine1 = new line(x1, y1, x2, y2, st2, stw2);
                                l2.Add(tempLine1);
                                Console.WriteLine("Input: 9 to exit, 1 to continue");
                                int t = Int32.Parse(Console.ReadLine());
                                if(t == 9){
                                    break;
                                }
                                Console.WriteLine("Next Line!");
                            }
                            tempShape = new polyGon(l2, st2, stw2, fill);
                        break;
                    }

                    c1.updateShape(hh, tempShape);
                    File.WriteAllTextAsync("fin.svg", c1.getSVG());  

                break;
            }

        }
    }
}

class Canvas : main{
    private string svg;
    private int order = 0;
    private List<shapes> els = new List<shapes>();
    private int width, height;
    public Canvas(int width, int height){
        this.width = width;
        this.height = height;
        svg = "<svg height=\"" + this.height +"\"" + " width=\"" + this.width + "\"" + ">\n</svg>";
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

    public void removeShape(int index){
        idHashSet.Remove(els[index - 1].getID());
        for(int i = 0; i < els.Count; i++){
            if(els[i].getID() == els[index - 1].getID()){
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