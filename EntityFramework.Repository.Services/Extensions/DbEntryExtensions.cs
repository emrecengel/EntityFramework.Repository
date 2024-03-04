/* using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Repository.Services.Extensions
{
    internal static class DbEntryExtensions
    {

        public static InternalEntityEntry RetrieveInternalEntityEntry(this EntityEntry entry)
        {

            return (InternalEntityEntry)entry.GetType().GetProperty("InternalEntry", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(entry);
        }

        public static EntityEntry ApplyCascadeDelete(this EntityEntry entry)
        {


            if ((entry.State == EntityState.Modified || entry.State == EntityState.Added) && entry.RetrieveInternalEntityEntry().HasConceptualNull)
            {
                entry.RetrieveInternalEntityEntry().HandleConceptualNulls(false, false, false);
            }

            if (entry.State == EntityState.Deleted)
            {
                ApplyCascadeDelete(entry.RetrieveInternalEntityEntry());

            }
             return entry;
        }

        private static void ApplyCascadeDelete(InternalEntityEntry internalEntry)
        {

            foreach (var foreignKey in internalEntry.EntityType.GetReferencingForeignKeys())
            {
                foreach (var dependentEntry in (internalEntry.StateManager.GetDependentsFromNavigation(internalEntry, foreignKey) ?? internalEntry.StateManager.GetDependents(internalEntry, foreignKey).ToList()))
                {
                    var dependent = dependentEntry.ToEntityEntry().RetrieveInternalEntityEntry();

                    if (dependent.EntityState != EntityState.Deleted && dependent.EntityState != EntityState.Detached)
                    {
                        if (foreignKey.DeleteBehavior == DeleteBehavior.Cascade)
                        {
                            var cascadeState = dependent.EntityState == EntityState.Added ? EntityState.Detached : EntityState.Deleted;
                            dependent.SetEntityState(cascadeState);
                            ApplyCascadeDelete(dependent);
                        }
                    }
                    else if (foreignKey.DeleteBehavior != DeleteBehavior.Restrict)
                    {
                        foreach (var dependentProperty in foreignKey.Properties)
                        {
                            dependent[dependentProperty] = null;


                        }

                        if (dependent.HasConceptualNull)
                        {
                            dependent.HandleConceptualNulls(false, false, false);
                        }
                    }
                }

            }
        }
    }
} */


