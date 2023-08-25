import { Evento } from "./Evento";

export interface Lote {
  ID: number;
  Nome: string;
  Preco:number;
  DateInicio?: Date;
  DateFim?: Date;
  Quantidade:number;
  EventoId: number;
  Evento: Evento;
}
