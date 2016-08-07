using System;
using System.Collections.Generic;
using IngswDev.EntityFramework.Models.Security;
using IngswDev.Extensions;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using IngswDev.EntityFramework.Models.Entities;

namespace IngswDev.EntityFramework
{
    public class IngswDevDBSeed : IIngswDevDBSeed
    {
        private readonly ILogger<IngswDevDBSeed> _logger;
        private readonly IngswDevDB _db;

        public IngswDevDBSeed(IngswDevDB db, ILogger<IngswDevDBSeed> logger)
        {
            _logger = logger;
            _db = db;
        }

        public Task SeedAsync()
        {
            if (_db == null)
                return Task.FromResult(0);
            _logger?.LogInformation("Running Seed method...");
            if (!_db.Users.Any(usr => usr.Email.Equals("admin@admin.com")))
            {
                _db.Users.Add(new User()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Email = "admin@admin.com",
                    Username = "administrator",
                    Name = "Administrator",
                    PasswordHash = "12345678".ComputeHash()
                });
            }
            if (!_db.Events.Any())
            {
                _db.Events.Add(new Event()
                {
                    Title = "Pool Party",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maximus dolor, inquit, brevis est. Vitiosum est enim in dividendo partem in genere numerare. Qui potest igitur habitare in beata vita summi mali metus? Sed tempus est, si videtur, et recta quidem ad me. Cur igitur, cum de re conveniat, non malumus usitate loqui? Negat esse eam, inquit, propter se expetendam. Duo Reges: constructio interrete.Si longus, levis; Negare non possum.Quasi ego id curem, quid ille aiat aut neget. Comprehensum, quod cognitum non habet? Urgent tamen et nihil remittunt.Nam quid possumus facere melius? Hoc ne statuam quidem dicturam pater aiebat, si loqui posset. Nam, ut sint illa vendibiliora, haec uberiora certe sunt.Et harum quidem rerum facilis est et expedita distinctio. Cum sciret confestim esse moriendum eamque mortem ardentiore studio peteret, quam Epicurus voluptatem petendam putat. Illud dico, ea, quae dicat, praeclare inter se cohaerere. Si quicquam extra virtutem habeatur in bonis.Nos commodius agimus.Huic mori optimum esse propter desperationem sapientiae, illi propter spem vivere. Ego vero volo in virtute vim esse quam maximam; Expressa vero in iis aetatibus, quae iam confirmatae sunt.Hi curatione adhibita levantur in dies, valet alter plus cotidie, alter videt.Quod quidem iam fit etiam in Academia.Haec quo modo conveniant, non sane intellego. Tu enim ista lenius, hic Stoicorum more nos vexat. Ut in geometria, prima si dederis, danda sunt omnia.Non dolere, inquam, istud quam vim habeat postea videro; Sed tu istuc dixti bene Latine, parum plane.Verba tu fingas et ea dicas, quae non sentias? Utilitatis causa amicitia est quaesita.Sequitur disserendi ratio cognitioque naturae; Illa videamus, quae a te de amicitia dicta sunt. Quid autem habent admirationis, cum prope accesseris? Potius inflammat, ut coercendi magis quam dedocendi esse videantur. Atque ab his initiis profecti omnium virtutum et originem et progressionem persecuti sunt.",
                    Location = "Miami, Beach FL",
                    Highlight = true,
                    ImageUri = "http://4.bp.blogspot.com/-pPb12pxuzpw/VYXxZbjPtzI/AAAAAAAAAKc/hoaXUCDTjoE/s640/pool1.jpg",
                    TargetDates = new List<EventDate>()
                    {
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(35),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        }
                    }
                });
            }
            _db.SaveChangesAsync();
            _logger?.LogInformation("Seed has completed");
            return Task.FromResult(0);
        }
    }
}
