import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { Constans } from '../util/constans';

@Pipe({
  name: 'DateFormat'
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  override transform(value: any, args?: any): any {
    return super.transform(value,Constans.DATETIME_FMT);
  }

}
