export interface Sejour {
    idSejour: number | null;
    nomSejour: string;
    descriptifSejour: string;
    lieuDepartSejour: string;
    dateDebutSejour: Date;
    dateFinSejour: Date;
    nomLieuSejour: string;
    prixSejour: number;
    minParticipantSejour:number;
    maxParticipantSejour:number;
    totalParticipantActuelSejour: number | null;
}
