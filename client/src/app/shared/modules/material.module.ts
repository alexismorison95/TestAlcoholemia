import { NgModule } from '@angular/core';

//material imports
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';


const cMaterialModules: any[] = [
    MatToolbarModule,
    MatButtonModule
];

@NgModule({

    imports: [ cMaterialModules ],
    exports: [ cMaterialModules ]
})
export class MaterialModule {}