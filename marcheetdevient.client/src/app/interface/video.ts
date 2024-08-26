export interface Video {
    id: number;
    dateSortie:Date;
    lien:string;
    titre:string;
    descriptif:string|null;
    idSejour:number|null;
}
