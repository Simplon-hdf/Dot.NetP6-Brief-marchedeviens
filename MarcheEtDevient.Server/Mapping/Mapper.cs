<<<<<<< HEAD
﻿using MarcheEtDevient.Server.ModelsDTO;
=======
﻿using Riok.Mapperly.Abstractions;
using MarcheEtDevient.Server.ModelsDTO;
>>>>>>> 6b28513e1dc508b3ddc556c93e2f478d16a0ab3e
using MarcheEtDevient.Server.Models;
using Riok.Mapperly.Abstractions;

namespace MarcheEtDevient.Server.Mapping
{
    [Mapper(EnumMappingStrategy=EnumMappingStrategy.ByName)]
    public static partial class Mapper
    {
        public static partial UtilisateurDTO MapToDto(this Utilisateur utilisateur);
        public static partial Utilisateur Map(this UtilisateurDTO utilisateur);

        public static partial VideoDTO MaptoDto(this Video video);
        public static partial Video Map(this VideoDTO video);

        public static partial SejourDTO MaptoDto(this Sejour sejour);
        public static partial Sejour Map(this SejourDTO sejour);

        public static partial ReserverDTO MaptoDto (this Reserver reserver);
        public static partial Reserver Map(this ReserverDTO reserver);

        public static partial PublicationDTO MaptoDTO (this Publication publication);
        public static partial Publication Map(this PublicationDTO publication);

        public static partial PhotoDTO MaptoDto(this Photo photo);
        public static partial Photo Map(this PhotoDTO photo);

        public static partial ContenuPublieDTO MaptoDto(this ContenuPublie Cpublie);
        public static partial ContenuPublie Map(this ContenuPublieDTO Cpubie);

        public static partial LoginDTO MaptoDto(this Utilisateur login);
        public static partial Utilisateur Map(this LoginDTO login);
    }
}
