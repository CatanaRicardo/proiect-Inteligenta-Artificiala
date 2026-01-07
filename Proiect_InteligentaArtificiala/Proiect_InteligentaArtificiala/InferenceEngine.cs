// Motor de inferenta cu unificare si forward chaining
class InferenceEngine
{
    public void ForwardChaining(KnowledgeBase kb)
    {
        bool factNou;

        do{
            factNou = false;

            foreach (var rule in kb.Rules){
                var substitutions = new Dictionary<string, string>();
                bool toatePotrivite = true;

                foreach (var premise in rule.Premises){
                    bool gasit = false;

                    foreach (var fact in kb.Facts){
                        var tempSub = new Dictionary<string, string>(substitutions);

                        if (premise.CanUnify(fact, tempSub)){
                            substitutions = tempSub;
                            gasit = true;
                            break;
                        }
                    }

                    if (!gasit){
                        toatePotrivite = false;
                        break;
                    }
                }

                if (toatePotrivite){
                    var concluzie = rule.Conclusion.ApplySubstitution(substitutions);

                    if (!kb.Facts.Any(f => f.ToString() == concluzie.ToString())){
                        Console.WriteLine("Se aplica regula:");
                        Console.WriteLine("  " + rule);
                        Console.WriteLine("Substitutii:");
                        foreach (var s in substitutions)
                            Console.WriteLine($"  {s.Key} = {s.Value}");
                        Console.WriteLine("Rezulta concluzia:");
                        Console.WriteLine("  " + concluzie);
                        Console.WriteLine();

                        kb.AddFact(concluzie);
                        factNou = true;
                    }
                }
            }
        }
        while (factNou);
    }
}
