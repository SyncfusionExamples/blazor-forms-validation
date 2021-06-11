using BlazorFormsValidation.Client.Shared;
using BlazorFormsValidation.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFormsValidation.Client.Pages
{
    public class RegistrationModalBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        ILogger<StudentRegistration> Logger { get; set; }

        protected StudentRegistration registration = new();

        protected CustomFormValidator customFormValidator;

        protected bool isRegistrationSuccess = false;


        protected async Task RegisterStudent()
        {
            customFormValidator.ClearFormErrors();
            isRegistrationSuccess = false;
            try
            {
                var response = await Http.PostAsJsonAsync("api/Student", registration);
                var errors = await response.Content.ReadFromJsonAsync<Dictionary<string, List<string>>>();

                if (response.StatusCode == HttpStatusCode.BadRequest && errors.Count > 0)
                {
                    customFormValidator.DisplayFormErrors(errors);
                    throw new HttpRequestException($"Validation failed. Status Code: {response.StatusCode}");
                }
                else
                {
                    isRegistrationSuccess = true;
                    Logger.LogInformation("The registration is successful");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }
    }
}
