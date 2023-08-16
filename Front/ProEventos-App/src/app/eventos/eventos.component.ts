import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos:any=[];
  public eventosFiltrados:any=[];
  widthImg:number=100;
  marginImg:number=2;
  mostrarImagem:boolean=true;
  private _filtroLista:string='';
  public get filtroLista(){
    return this._filtroLista;
  }
  public set filtroLista(value:string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista):this.eventos;
  }
  filtrarEventos(filtraPor:string):any{
    filtraPor = filtraPor.toLowerCase();
    return this.eventos.filter(
      (      evento: { tema: string;local:string })=>evento.tema.toLowerCase().indexOf(filtraPor)!==-1 ||
      evento.local.toLowerCase().indexOf(filtraPor)!==-1
    );
  }
  constructor(private http:HttpClient){}
  alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }
  public GetEventos():void{
    this.http.get('https://localhost:5001/api/Eventos').subscribe(
      response=>{
        this.eventos=response;
        this.eventosFiltrados=this.eventos;
      },
      error=>console.log(error)
    );

  }

  ngOnInit(): void {
    this.GetEventos();
  }
}
