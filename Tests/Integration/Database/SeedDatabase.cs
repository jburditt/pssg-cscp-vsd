public class SeedDatabase(
    DatabaseContext databaseContext, IContractRepository contractRepository, IProgramRepository programRepository, IPaymentScheduleRepository paymentScheduleRepository,
    IEntitlementRepository entitlementRepository, IMapper mapper)
{
    public void Seed()
    {
        // Seed the database
        Guid id;

        //foreach (var contract in FakeData.Contracts)
        //{
        //    try
        //    {
        //        id = contractRepository.Upsert(contract);
        //        Console.WriteLine($"Inserted contract with id {id}");
        //    } catch { /* gulp */ }
        //}

        //foreach (var program in FakeData.Programs)
        //{
        //    try
        //    {
        //        id = programRepository.Upsert(program);
        //        Console.WriteLine($"Inserted program with id {id}");
        //    }
        //    catch { /* gulp */ }
        //}

        //foreach (var n in FakeData.PaymentSchedules)
        //{
        //    try
        //    {
        //        id = paymentScheduleRepository.Upsert(n);
        //        Console.WriteLine($"Inserted payment schedule with id {id}");
        //    }
        //    catch { /* gulp */ }
        //}

        // TODO this will fail on INSERT because you can't insert with StatusCode Entitlement_StatusCode.Approved. BUT you can insert with Requested and then update to Approved
        //foreach (var n in FakeData.Entitlements)
        //{
        //    try
        //    {
        //        var existingEntitlementEntity = databaseContext.Vsd_EntitlementSet.FirstOrDefault(x => x.Id == n.Id);
        //        var entitlementEntity = mapper.Map<Vsd_Entitlement>(n);
        //        if (existingEntitlementEntity != null)
        //        {
        //            databaseContext.Detach(existingEntitlementEntity);
        //            databaseContext.Attach(entitlementEntity);
        //            databaseContext.UpdateObject(entitlementEntity);
        //        }
        //        else
        //        {
        //            // Dynamics will not allow inser
        //            if (n.StatusCode == EntitlementStatusCode.Approved)
        //            {
        //                entitlementEntity.StatusCode = EntitlementStatusCode.Requested;
        //                databaseContext.AddObject(entitlementEntity);
        //                entitlementEntity.StatusCode = Vsd_Entitlement_StatusCode.Approved;
        //                databaseContext.UpdateObject(entitlementEntity);
        //            }
        //            else
        //            {
        //                databaseContext.AddObject(mapper.Map<Vsd_Entitlement>(n));
        //            }
        //        }
        //        // payment schedule children
        //        if (n.PaymentSchedules != null)
        //        {
        //            foreach (var paymentSchedule in n.PaymentSchedules)
        //            {
        //                var paymentScheduleEntity = mapper.Map<Vsd_PaymentSchedule>(paymentSchedule);
        //                paymentScheduleEntity.Vsd_EntitlementId = entitlementEntity.ToEntityReference();
        //                databaseContext.AddRelatedObject(entitlementEntity, Vsd_Entitlement.Fields.Vsd_Vsd_Entitlement_Vsd_PaymentSchedule.ToLower(), paymentScheduleEntity);
        //            }
        //        }
        //        databaseContext.SaveChanges();
        //        Console.WriteLine($"Inserted entitlement with id {n.Id}");
        //    }
        //    catch { /* gulp */ }
        //}

        // TODO move to PaymentSchedule.Upsert
        foreach (var paymentSchedule in FakeData.PaymentSchedules)
        {
            try
            {
                var existingPaymentSchedule = databaseContext.Vsd_PaymentScheduleSet.FirstOrDefault(x => x.Id == paymentSchedule.Id);
                var paymentScheduleEntity = mapper.Map<Vsd_PaymentSchedule>(paymentSchedule);
                if (existingPaymentSchedule != null)
                {
                    databaseContext.Detach(existingPaymentSchedule);
                    databaseContext.Attach(paymentScheduleEntity);
                    databaseContext.UpdateObject(paymentScheduleEntity);
                }
                else
                {
                    databaseContext.AddObject(paymentScheduleEntity);
                }
                // children
                if (paymentSchedule.Entitlements != null)
                {
                    foreach (var entitlement in paymentSchedule.Entitlements)
                    {
                        var existingEntitlement = databaseContext.Vsd_EntitlementSet.FirstOrDefault(x => x.Id == entitlement.Id);
                        var entitlementEntity = mapper.Map<Vsd_Entitlement>(entitlement);
                        if (existingEntitlement != null)
                        {
                            databaseContext.Detach(existingEntitlement);
                            databaseContext.Attach(entitlementEntity);
                            databaseContext.UpdateObject(entitlementEntity);
                        }
                        else
                        {
                            //entitlementEntity.Vsd_EntitlementId = paymentSchedule.ToEntityReference();
                            databaseContext.AddRelatedObject(paymentScheduleEntity, Vsd_Entitlement.Fields.Vsd_Vsd_Entitlement_Vsd_PaymentSchedule.ToLower(), entitlementEntity);

                            // Dynamics will not allow inser
                            //if (entitlement.StatusCode == EntitlementStatusCode.Approved)
                            //{
                            //    entitlementEntity.StatusCode = Vsd_Entitlement_StatusCode.Requested;
                            //    databaseContext.AddObject(entitlementEntity);
                            //    entitlementEntity.StatusCode = Vsd_Entitlement_StatusCode.Approved;
                            //    databaseContext.UpdateObject(paymentScheduleEntity);
                            //}
                            //else
                            //{
                            //    databaseContext.AddObject(mapper.Map<Vsd_Entitlement>(paymentSchedule));
                            //}
                        }
                        Console.WriteLine($"Inserted entitlement with id {entitlement.Id}");
                    }
                }
                databaseContext.SaveChanges();
                Console.WriteLine($"Inserted payment schedule with id {paymentSchedule.Id}");
            }
            catch { /* gulp */ }
        }


        //entitlementRepository.Delete(FakeData.Entitlements[0].Id);
        //var paymentSchedule = databaseContext.Vsd_PaymentScheduleSet.Where(x => x.Id == FakeData.PaymentSchedules[0].Id).Single();
        //var entitlement = databaseContext.Vsd_EntitlementSet.Where(x => x.Id == FakeData.Entitlements[0].Id).Single();
        //databaseContext.AddRelatedObject(entitlement, Vsd_Entitlement.Fields.Vsd_Vsd_Entitlement_Vsd_PaymentSchedule.ToLower(), paymentSchedule);
    }

    public void Clear()
    {
        // Clear all the fake data in database
        bool isDeleted;
        //foreach (var contract in FakeData.Contracts)
        //{
        //    try
        //    {
        //        isDeleted = contractRepository.TryDelete(contract.Id);
        //        Console.WriteLine($"Deleted contract with id {contract.Id} {isDeleted}");
        //    }
        //    catch { /* gulp */ }
        //}

        //foreach (var program in FakeData.Programs)
        //{
        //    try
        //    {
        //        isDeleted = programRepository.Delete(program.Id);
        //        Console.WriteLine($"Deleted program with id {program.Id} {isDeleted}");
        //    }
        //    catch { /* gulp */ }
        //}

        //foreach (var n in FakeData.PaymentSchedules)
        //{
        //    try
        //    {
        //        isDeleted = paymentScheduleRepository.Delete(n.Id);
        //        Console.WriteLine($"Deleted payment schedule with id {n.Id} {isDeleted}");
        //    }
        //    catch { /* gulp */ }
        //}

        //foreach (var n in FakeData.Entitlements)
        //{
        //    try
        //    {
        //        //var entity = mapper.Map<Vsd_Entitlement>(n);
        //        //databaseContext.Attach(entity);
        //        //entity.Vsd_BenefitCategoryId = null;
        //        //entity.Vsd_BenefitSubtypeId = null;
        //        //entity.Vsd_BenefitTypeId = null;
        //        //databaseContext.UpdateObject(entity);
        //        //databaseContext.SaveChanges();
        //        foreach (var m in n.PaymentSchedules)
        //        {
        //            isDeleted = paymentScheduleRepository.Delete(m.Id);
        //            Console.WriteLine($"Deleted payment schedule with id {m.Id} {isDeleted}");
        //        }
        //        isDeleted = entitlementRepository.Delete(n.Id);
        //        Console.WriteLine($"Deleted entitlement with id {n.Id} {isDeleted}");
        //    }
        //    catch { /* gulp */ }
        //}

        foreach (var n in FakeData.PaymentSchedules)
        {
            try
            {
                //var entity = mapper.Map<Vsd_Entitlement>(n);
                //databaseContext.Attach(entity);
                //entity.Vsd_BenefitCategoryId = null;
                //entity.Vsd_BenefitSubtypeId = null;
                //entity.Vsd_BenefitTypeId = null;
                //databaseContext.UpdateObject(entity);
                //databaseContext.SaveChanges();
                foreach (var m in n.Entitlements)
                {
                    isDeleted = entitlementRepository.Delete(m.Id);
                    Console.WriteLine($"Deleted payment schedule with id {m.Id} {isDeleted}");
                }
                isDeleted = paymentScheduleRepository.Delete(n.Id);
                Console.WriteLine($"Deleted entitlement with id {n.Id} {isDeleted}");
            }
            catch { /* gulp */ }
        }
    }
}
