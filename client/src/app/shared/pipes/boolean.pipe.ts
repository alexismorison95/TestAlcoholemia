import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'booleanPipe'
})
export class BooleanPipe implements PipeTransform {

  transform(value: boolean, ...args: unknown[]): unknown {
    return value ? "Activo" : "Inactivo";
  }

}
