package at.sampas.personal_share;

import org.junit.jupiter.api.Test;

public class OnboardingTests {
    // onboarding should return correct state
    // onboarding should create user
    // created user should exist and have admin rights
    // onboarding should then return completed
    // login etc. should now work

    @Test
    public void TestOnboardingShouldBeActiveOnAnEmptySystem() {

    }

    @Test
    public void TestOnboardingShouldCreateUserWithAdminRights() {
        Email email = new Email("test@test.com");
        Password password = new Password()
        Onboarding onboarding = new Onboarding();
        onboarding.createUser()
    }

    @Test
    public void TestOnboardingShouldBeCompleteAfterUserCreation() {

    }

    @Test
    public void TestOnboardingShouldRejectUserCreationAfterCompletion() {

    }
}
