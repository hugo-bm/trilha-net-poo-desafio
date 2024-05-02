using DesafioPOO.Models;

Nokia nk = new Nokia("(11) 99999-9999","NK-40X","983856983345014",16);

nk.Ligar();
nk.ReceberLigacao();
nk.InstalarAplicativo("DIO");

Iphone ip = new Iphone("(11) 99999-9999","NK-40X","983856983345014",16);

ip.Ligar();
ip.ReceberLigacao();
ip.InstalarAplicativo("DIO for Iphone");