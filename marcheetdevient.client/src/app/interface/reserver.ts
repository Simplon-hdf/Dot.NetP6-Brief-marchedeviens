export interface Reserver {
    idUtilisateur: number;
    idSejour: number;
    idReserver: number;
    nombrePlaceReserver: number;
    validation: boolean;
    datePaiment: Date|null;
}
