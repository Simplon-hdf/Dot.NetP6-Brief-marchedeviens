export interface Sejour {
    id: number | null;
    nomSejour: string;
    descriptif: string;
    lieuDepart: string;
    dateDebut: Date;
    dateFin: Date;
    nomDuLieu: string;
    prix: number;
    minParticipant:number;
    maxParticipant:number;
    actualParticipant: number | null;
}
