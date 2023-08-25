
import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../../model/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

//import { Evento } from '../model/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventos:Evento[]=[];
  public eventosFiltrados:Evento[]=[];
  public widthImg:number=100;
  public marginImg:number=2;
  public mostrarImagem:boolean=true;
  private _filtroLista:string='';
  public get filtroLista(){
    return this._filtroLista;
  }
  public set filtroLista(value:string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista):this.eventos;
  }
  public filtrarEventos(filtraPor:string):Evento[] {
    filtraPor = filtraPor.toLowerCase();
    return this.eventos.filter(
      (      evento: { tema: string;local:string })=>evento.tema.toLowerCase().indexOf(filtraPor)!==-1 ||
      evento.local.toLowerCase().indexOf(filtraPor)!==-1
    );
  }
  constructor(private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr:ToastrService,
    private spinner: NgxSpinnerService ){}
  public alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }
  public GetEventos():void{
    this.eventoService.getEventos().subscribe({
      next:(_eventos:Evento[])=>{
        this.eventos=_eventos;
        this.eventosFiltrados=this.eventos;
      },
      error:(error :any)=>{
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os Eventos','Error!');
      },
      complete: ()=>this.spinner.hide()

      });
    }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Deletado! Excluído com sucesso');
  }

  decline(): void {
    this.modalRef?.hide();

  }

  public ngOnInit(): void {
    this.spinner.show();
    this.GetEventos();

    setTimeout(()=>{
      //Spinner sai depois de 5 segundos.
      this.spinner.hide();
    },5000);
  }
}
